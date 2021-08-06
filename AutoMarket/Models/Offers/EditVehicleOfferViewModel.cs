using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMarket.Data.Models.Enum;


namespace AutoMarket.Models.Offers
{
    public class EditVehicleOfferViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Brand")]
        public string Make { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Body type")]
        public BodyType BodyType { get; set; }

        [Display(Name = "Manufacturing year")]
        public int ManufacturingYear { get; set; }

        [Display(Name = "Engine capacity")]
        public decimal EngineCapacity { get; set; }

        [Display(Name = "Horse Power")]
        public int HorsePower { get; set; }

        [Display(Name = "Engine type")]
        public EngineType EngineType { get; set; }

        [Display(Name = "Transmission")]
        public TransmissionType Transmission { get; set; }

        [Display(Name = "Mileage (km)")]
        public int Мileage { get; set; }

        [Display(Name = "Color")]
        public Color Color { get; set; }

        [Display(Name = "Euro standart")]
        public EuroStandart EuroStandart { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price (euro)")]
        public int Price { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
