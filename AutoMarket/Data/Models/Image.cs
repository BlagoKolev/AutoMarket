using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Data.Models
{
    public class Image
    {
        public string Id { get; set; }
        public string Extension { get; set; }
        public int? PartOfferId { get; set; }
        public PartOffer PartOffer{ get; set; }
        public int? VehicleOfferId { get; set; }
        public VehicleOffer VehicleOffer { get; set; }
    }
}
