using AutoMarket.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models.Offers
{
    public class MyOffersViewModel
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public Color Color { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public PartStatus Status { get; set; }
        public string Image { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
