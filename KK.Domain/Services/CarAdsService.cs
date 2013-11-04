using System;
using System.Collections.Generic;
using KK.Domain.Models;
using KK.Domain.Repositories;
using KK.Domain.Repositories.Interfaces;
using KK.Domain.Services.Interfaces;

namespace KK.Domain.Services
{
    /// <summary>
    /// This is the service where you embed all the logic of your data such as sorting
    /// </summary>
    public class CarAdsService : ICarAdsService
    {
        private readonly ICarAdsRepository _carAdsRepository;

        //Fix this autofac
        

        public CarAdsService(ICarAdsRepository carAdsRepository)
        {
            _carAdsRepository = carAdsRepository;
        }


        #region ICarAdsService Members

        public List<CarAds> GetAll()
        {
            //you can add business rules here.
            return _carAdsRepository.GetAll();
        }

        public CarAds GetById(Guid id)
        {
            return _carAdsRepository.GetById(id);
        }

        #endregion
    }
}
