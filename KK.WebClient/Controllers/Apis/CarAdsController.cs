using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KK.Domain.Models;
using KK.Domain.Services.Interfaces;

namespace KK.WebClient.Controllers.Apis
{
    /// <summary>
    /// API controller to Car Ads
    /// </summary>
    public class CarAdsController : ApiController
    {
        private readonly ICarAdsService _carAdsService;

        public CarAdsController(ICarAdsService carAdsService)
        {
            _carAdsService = carAdsService;
        }

        // GET: /api/carAds
        public IEnumerable<CarAds> Get()
        {
            return _carAdsService.GetAll();
        }

        // GET: /api/carAds/{id}
        public CarAds Get(Guid id)
        {
            return _carAdsService.GetById(id);
        }

    }
}
