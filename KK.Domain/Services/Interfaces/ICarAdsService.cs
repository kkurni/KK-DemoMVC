using System;
using System.Collections.Generic;
using KK.Domain.Models;

namespace KK.Domain.Services.Interfaces
{
    public interface ICarAdsService : IServices
    {
        List<CarAds> GetAll();
        CarAds GetById(Guid id);
    }
}
