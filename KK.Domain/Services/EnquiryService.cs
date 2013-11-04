using System;
using System.Collections.Generic;
using KK.Domain.Models;
using KK.Domain.Repositories;
using KK.Domain.Repositories.Interfaces;
using KK.Domain.Services.Interfaces;

namespace KK.Domain.Services
{
    public class EnquiryService : IEnquiryService
    {
        private readonly IEnquiryRepository _enquiryRepository;

        public EnquiryService(IEnquiryRepository enquiryRepository)
        {
            _enquiryRepository = enquiryRepository;
        }


        #region IEnquiryService Members

        public List<Enquiry> GetAll()
        {
            return _enquiryRepository.GetAll();
        }

        public Guid AddEnquiry(Enquiry newEnquiry)
        {
            //validate entry
            //TODO: we can use better validation for this. such as Fluent validation
            if (String.IsNullOrEmpty(newEnquiry.Name) || String.IsNullOrEmpty(newEnquiry.EmailAddress))
            {
                //better to use custom exceptioin
                throw new ApplicationException("Name or Email can't be empty");
            }

            return _enquiryRepository.AddEnquiry(newEnquiry);
        }

        #endregion
    }
}
