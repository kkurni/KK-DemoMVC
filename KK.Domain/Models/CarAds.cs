using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KK.Domain.Models
{
    public class CarAds
    {
        public Guid Id { get; set; }
        public Car CarListed { get; set; }
        public SellerDetail ContactDetail { get; set; }
        public string Comments { get; set; }
        public DateTime ListedDate { get; set; }
    }

}