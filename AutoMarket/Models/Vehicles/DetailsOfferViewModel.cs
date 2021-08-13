using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMarket.Data.Models.Enum;

namespace AutoMarket.Models.Offers
{
    public class DetailsOfferViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Brand")]
        public string Make { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Body type")]
        public string BodyType { get; set; }

        [Display(Name = "Manufacturing year")]
        public int ManufacturingYear { get; set; }

        [Display(Name = "Engine capacity")]
        public decimal EngineCapacity { get; set; }

        [Display(Name = "Horse power")]
        public int HorsePower { get; set; }

        [Display(Name = "Engine type")]
        public EngineType EngineType { get; set; }

        [Display(Name = "Transmission")]
        public string Transmission { get; set; }

        [Display(Name = "Mileage (km)")]
        public int Мileage { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Euro standart")]
        public string EuroStandart { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        public string Email { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
