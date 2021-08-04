﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Data.Models
{
    public class Image
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string Extension { get; set; }
        public string PartOfferId { get; set; }
        public PartOffer PartOffer{ get; set; }
        public string VehicleOfferId { get; set; }
        public VehicleOffer VehicleOffer { get; set; }
    }
}