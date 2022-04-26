using System;
using AutoMarket.Data.Models.Enum;

namespace AutoMarket.Models.Offers
{
    public class MyOffersViewModel
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Title { get; set; }
        public Color Color { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public PartStatus Status { get; set; }
        public EngineType EngineType { get; set; }
        public int? ManufactoringYear { get; set; }
        public string Image { get; set; }
        public DateTime CreatedOn { get; set; }
        public string  OwnerId { get; set; }
    }
}
