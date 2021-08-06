using AutoMarket.Data.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Models.Offers
{
    public class MyVehicleOffersViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Brand")]
        public string Make { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Color")]
        public Color Color { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
