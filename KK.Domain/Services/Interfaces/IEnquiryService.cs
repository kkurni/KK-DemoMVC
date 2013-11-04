using System.Collections.Generic;
using KK.Domain.Models;
using System;

namespace KK.Domain.Services.Interfaces
{
    public interface IEnquiryService : IServices
    {
        List<Enquiry> GetAll();
        Guid AddEnquiry(Enquiry newEnquiry);
    }
}
