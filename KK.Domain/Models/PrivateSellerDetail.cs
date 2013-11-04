using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KK.Domain.Models
{
    public class PrivateSellerDetail : SellerDetail
    {
        public string ContactName { get; set; }
        public string Phone { get; set; }
    }

}