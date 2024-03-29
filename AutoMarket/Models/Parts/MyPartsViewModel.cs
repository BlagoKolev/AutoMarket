﻿using AutoMarket.Data.Models.Enum;

namespace AutoMarket.Models.Parts
{
    public class MyPartsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public PartStatus Status { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
