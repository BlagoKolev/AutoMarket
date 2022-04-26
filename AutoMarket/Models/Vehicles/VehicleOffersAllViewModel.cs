using AutoMarket.Data.Models.Enum;

namespace AutoMarket.Models.Vehicles
{
    public class VehicleOffersAllViewModel
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public Color Color { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public EngineType EngineType { get; set; }
        public int ManufactoringYear { get; set; }
    }
}
