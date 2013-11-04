using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KK.Domain.Models;
using KK.Domain.Services.Interfaces;

namespace KK.WebClient.Areas.oldCar.Controllers
{
    public class AdsController : Controller
    {
        
        private readonly ICarAdsService _carAdsService;

        public AdsController(ICarAdsService carAdsService)
        {
            _carAdsService = carAdsService;
        }

        // GET: /oldCar/ads/
        public ActionResult Index()
        {
            return View(_carAdsService.GetAll());
        }

        // GET: /oldCar/ads/detail/{id}
        public ActionResult Detail(Guid id)
        {
            var detail = _carAdsService.GetById(id);
            return View(detail);
        }

    }
}
