using AutoMarket.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models.Offers
{
    public class VehicleOffersAllViewModel
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
