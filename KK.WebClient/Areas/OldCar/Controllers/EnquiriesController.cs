using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KK.Domain.Models;
using KK.Domain.Services.Interfaces;
using KK.WebClient.Models;

namespace KK.WebClient.Areas.oldCar.Controllers
{
    public class EnquiriesController : Controller
    {        
        private readonly ICarAdsService _carAdsService;
        private readonly IEnquiryService _enquiryService;

        public EnquiriesController(ICarAdsService carAdsService, IEnquiryService enquiryService)
        {
            _carAdsService = carAdsService;
            _enquiryService = enquiryService;
        }

        // GET: /oldCar/enquiries
        public ActionResult Index()
        {
            return View(_enquiryService.GetAll());
        }


        // POST: /oldCar/enquiries/add
        [HttpPost]        
        [ValidateAntiForgeryToken]
        public ActionResult AddEnquiry(EnquiryViewModel enquiryViewModel)
        {
            var enquiry = new Enquiry
                          {
                              CarAds = _carAdsService.GetById(enquiryViewModel.CarAdsId),
                              EmailAddress = enquiryViewModel.EmailAddress, 
                              Name = enquiryViewModel.Name
                          };

            _enquiryService.AddEnquiry(enquiry);
            return View(enquiry);
        }
    }
}
