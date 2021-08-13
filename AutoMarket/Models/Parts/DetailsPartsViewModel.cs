using System;
using System.Collections.Generic;
using AutoMarket.Data.Models.Enum;

namespace AutoMarket.Models.Parts
{
    public class DetailsPartsViewModel
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }
        public string VehicleType { get; set; }
        public int PartId { get; set; }
        public ICollection<string> Images { get; set; }
        public string Name { get; set; }
        public string PartCategory { get; set; }
        public PartStatus Status { get; set; }
    }
}
