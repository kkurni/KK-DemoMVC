using System;
using System.Collections.Generic;
using System.Linq;
using KK.Domain.Models;
using KK.Domain.Repositories.Interfaces;

namespace KK.Domain.Repositories
{
    /// <summary>
    /// This just mock repository
    /// </summary>
    public class CarAdsRepositories : ICarAdsRepository
    {
        private static List<CarAds> _mockDb;
        static CarAdsRepositories()
        {
            _mockDb = GenerateMockListing();
        }

        
        public List<CarAds> GetAll()
        {
            //this is just Mock DB but it should access DB using Dapper / ORM tools
            return _mockDb;
        }

        public CarAds GetById(Guid id)
        {
            return _mockDb.FirstOrDefault(t => t.Id == id);
        }

        #region <<Generate Mock>>
        private static CarAds CreateAds(string make, string model, int year, CarPriceType priceType, decimal price, string comments)
        {
            return new CarAds()
            {
                Id = Guid.NewGuid(),
                CarListed = new Car()
                {
                    Id = Guid.NewGuid(),
                    Make = make,
                    Model = model,
                    Year = year,
                    PriceType = priceType,
                    Price = price,
                },
                ListedDate = DateTime.Now,
                Comments = comments
            };
        }

        private static CarAds CreateDealerAds(string make, string model, int year, CarPriceType priceType, decimal price, string comments, string email, string abn)
        {
            var ads = CreateAds(make,model,year,priceType,price,comments);
            ads.ContactDetail = new DealerSellerDetail
                {
                    EmailAddress = email,
                    DealerABN = abn
                };
            return ads;
        }
        private static CarAds CreatePrivateAds(string make, string model, int year, CarPriceType priceType, decimal price, string comments, string email, string contactName, string phone)
        {
            
            var ads = CreateAds(make,model,year,priceType,price,comments);
            ads.ContactDetail = new PrivateSellerDetail
                {
                    EmailAddress = email,
                    ContactName = contactName,
                    Phone = phone
                };
            return ads;
        }

        private static List<CarAds> GenerateMockListing()
        {
            return new List<CarAds>
            {
                CreateDealerAds("Honda","Vti",2013,CarPriceType.DAP,25000,"This is awesome car","dealer@test.com","123 234 321 3244"),                
                CreateDealerAds("BMW","C200",2012,CarPriceType.EGC,55000,"This is BMW car","dealer2@test.com","183 234 321 3244"),               
                CreateDealerAds("Mazda","Type Z",2011,CarPriceType.POA,0,"This is Mazda car","dealer3@test.com","193 234 321 3244"),
                CreatePrivateAds("Mazda","Type Z",2011,CarPriceType.POA,0,"This is Mazda car","private@test.com","kk","032423123"),              
                CreatePrivateAds("Toyota","Camry",2012,CarPriceType.EGC,15000,"This is Toyota car","private1@test.com","kk1","032423123"),                
                CreatePrivateAds("Honda","Jazz",2013,CarPriceType.DAP,18000,"This is Jazz car","private2@test.com","kk2","032423123"),
            };
        }
        #endregion
    }
}
