using System;
using System.Collections.Generic;
using KK.Domain.Models;
using KK.Domain.Repositories.Interfaces;

namespace KK.Domain.Repositories
{
    public class EnquiriesRepositories : IEnquiryRepository
    {
        private static List<Enquiry> _mockDb;
        static EnquiriesRepositories()
        {
            _mockDb = new List<Enquiry>()
                             {
                                 new Enquiry(){Id= Guid.Empty, Name="testEnquiry", EmailAddress="test@test.com"}
                             };
        }


        public List<Enquiry> GetAll()
        {
            //this is just Mock DB but it should access DB using Dapper / ORM tools
            return _mockDb;
        }

        public Guid AddEnquiry(Enquiry newEnquiry)
        {
            newEnquiry.Id = Guid.NewGuid();
            _mockDb.Add(newEnquiry);
            return newEnquiry.Id;
        }
    }
}
