using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KK.Domain.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public CarPriceType PriceType { get; set; }
        public decimal Price { get; set; }
    }

}