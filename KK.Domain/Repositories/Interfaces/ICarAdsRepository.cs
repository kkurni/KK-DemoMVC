using System;
using System.Collections.Generic;
using KK.Domain.Models;

namespace KK.Domain.Repositories.Interfaces
{
    public interface ICarAdsRepository :IRepositories
    {
        List<CarAds> GetAll();
        CarAds GetById(Guid id);
    }
}
