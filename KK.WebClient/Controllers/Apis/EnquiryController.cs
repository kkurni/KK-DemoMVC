using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KK.Domain.Models;
using KK.Domain.Services.Interfaces;
using KK.WebClient.Models;

namespace KK.WebClient.Controllers.Apis
{
    /// <summary>
    /// API controller to Enquiry
    /// </summary>    
    public class EnquiryController : ApiController
    {
        private readonly IEnquiryService _enquiryService;
        private readonly ICarAdsService _carAdsService;

        public EnquiryController(IEnquiryService enquiryService, ICarAdsService carAdsService)
        {
            _enquiryService = enquiryService;
            _carAdsService = carAdsService;
        }

        // GET: /api/enquiry
        public IEnumerable<Enquiry> Get()
        {
            return _enquiryService.GetAll();
        }

        // POST: /api/enquiry
        public Guid Post(EnquiryViewModel enquiryViewModel)
        {
            var enquiry = new Enquiry
            {
                CarAds = _carAdsService.GetById(enquiryViewModel.CarAdsId),
                EmailAddress = enquiryViewModel.EmailAddress,
                Name = enquiryViewModel.Name
            };

            return _enquiryService.AddEnquiry(enquiry);
        }
    }
}
