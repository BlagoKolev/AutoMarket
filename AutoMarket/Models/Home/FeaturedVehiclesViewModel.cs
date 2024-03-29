﻿using AutoMarket.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models.Home
{
    public class FeaturedVehiclesViewModel
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public Color Color { get; set; }
        public EngineType EngineType { get; set; }
        public int ManufactoringYear { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
