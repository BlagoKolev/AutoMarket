using System.ComponentModel.DataAnnotations;
using AutoMarket.Data;
using AutoMarket.Data.Models.Enum;

namespace AutoMarket.Models.Offers
{
    public class MyVehicleOffersViewModel
    {
        public string Id { get; set; }

        [Display(Name = GlobalConstants.DisplayName.Brand)]
        public string Make { get; set; }

        public string Model { get; set; }

        public Color Color { get; set; }

        public int Price { get; set; }
        public string Image { get; set; }
    }
}
