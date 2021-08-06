using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using AutoMarket.Controllers;
using AutoMarket.Data.Models.Enum;
using AutoMarket.Data;

namespace AutoMarket.Models.Offers
{
    public class CreateVehicleOfferViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "The 'Brand' field is required")]
        [StringLength(15, ErrorMessage = "The 'Brand' field must me between 3 and 15 symbols.", MinimumLength = 3)]
        [Display(Name = "Brand")]
        public string Make { get; set; }

        [Required(ErrorMessage = "The 'Model' field is required")]
        [StringLength(20, ErrorMessage = "The 'Model' field must be between 1 and 20 symbols.", MinimumLength = 1)]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "The 'Body type' field is required.")]
        [Display(Name = "Body type")]
        public BodyType BodyType { get; set; }

        [Required(ErrorMessage = "The 'Manufacturing year' field is required")]
        [ManufactoringYear(1900)]
        [Display(Name = "Manufacturing year")]
        public int ManufacturingYear { get; set; }

        [Required(ErrorMessage = "The 'Engine capacity' field is required.")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(typeof(decimal), "0.1", "1000000", ErrorMessage = "Engine capacity must be between 0,1 and 1000000.")]
        [Display(Name = "Engine Capacity")]
        public decimal EngineCapacity { get; set; }

        [Required(ErrorMessage = "The 'Horse power' field is required.")]
        [Range(0, 100000, ErrorMessage = "Horse power must be between 0 и 100000 h.p. .")]
        [Display(Name = "Horse power")]
        public int HorsePower { get; set; }

        [Required(ErrorMessage = "The 'Engine type' field is required.")]
        [Display(Name = "Engine type")]
        public EngineType EngineType { get; set; }

        [Required(ErrorMessage = "The 'Transmission' field s required.")]
        [Display(Name = "Transmission")]
        public TransmissionType Transmission { get; set; }


        [Required(ErrorMessage = "The 'Mileage' field s required.")]
        [Display(Name = "Mileage (km)")]
        [Range(0, 2000000, ErrorMessage = "The 'Mileage' field must be between 0 и 2 mln. km.")]
        public int Мileage { get; set; }


        [Required(ErrorMessage = "The 'Color' field s required.")]
        [Display(Name = "Color")]
        public Color Color { get; set; }


        [Required(ErrorMessage = "The 'Euro standar' field s required.")]
        [Display(Name = "Euro standart")]
        public EuroStandart EuroStandart { get; set; }

        [Required(ErrorMessage = "The 'Phone' field s required.")]
        [MaxLength(15, ErrorMessage = "The 'Phone' field cannot be longer than 15 symbols")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid E-mail form 'xxx@xxx.xx'.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [MaxLength(500, ErrorMessage = "The 'Description' field cannot be longer than 500 symbols.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }


        [Required(ErrorMessage = "The 'Price' field is requred.")]
        [Range(0, int.MaxValue, ErrorMessage = "The 'Price' field must be between 0 и 2 000 000 000 euro.")]
        [Display(Name = "Price")]
        public int Price { get; set; }

        [MaxLength(GlobalConstants.LocationLength, ErrorMessage = "The 'Location' field is requred.")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Upload images")]
        public ICollection<IFormFile> Images { get; set; }
    }


}
