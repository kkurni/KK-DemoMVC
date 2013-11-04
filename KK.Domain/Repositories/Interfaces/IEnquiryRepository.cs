using System.Collections.Generic;
using KK.Domain.Models;
using System;

namespace KK.Domain.Repositories.Interfaces
{
    public interface IEnquiryRepository :IRepositories
    {
        List<Enquiry> GetAll();
        Guid AddEnquiry(Enquiry newEnquiry);
    }
}
