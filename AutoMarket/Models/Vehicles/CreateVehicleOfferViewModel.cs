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

        [Display(Name = GlobalConstants.DisplayName.Brand)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [StringLength(15, ErrorMessage = GlobalConstants.StringInRange, MinimumLength = 3)]
        public string Make { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [StringLength(20, ErrorMessage = GlobalConstants.StringInRange, MinimumLength = 1)]
        public string Model { get; set; }

        [Display(Name = GlobalConstants.DisplayName.BodyType)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        public BodyType BodyType { get; set; }

        [Display(Name = GlobalConstants.DisplayName.ManufacturingYear)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [ManufactoringYear(1900)]
        public int ManufacturingYear { get; set; }

        [Display(Name = GlobalConstants.DisplayName.EngineCapacity)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(typeof(decimal), "0.1", "999", ErrorMessage = GlobalConstants.ValueInRange)]
        public decimal EngineCapacity { get; set; }

        [Display(Name = GlobalConstants.DisplayName.HorsePower)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [Range(0, 100000, ErrorMessage = GlobalConstants.ValueInRange)]
        public int HorsePower { get; set; }

        [Display(Name = GlobalConstants.DisplayName.EngineType)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        public EngineType EngineType { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        public TransmissionType Transmission { get; set; }


        [Display(Name = GlobalConstants.DisplayName.Mileage)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [Range(0, 2000000, ErrorMessage = GlobalConstants.ValueInRange)]
        public int Мileage { get; set; }


        [Required(ErrorMessage = GlobalConstants.Required)]
        public Color Color { get; set; }


        [Display(Name = GlobalConstants.DisplayName.EuroStandart)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        public EuroStandart EuroStandart { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [MaxLength(15, ErrorMessage = GlobalConstants.MaxLength)]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = GlobalConstants.ValidEmailFormat)]
        [Display(Name = GlobalConstants.DisplayName.Email)]
        public string Email { get; set; }

        [MaxLength(500, ErrorMessage = GlobalConstants.MaxLength)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        [Required(ErrorMessage = GlobalConstants.Required)]
        [Range(0, int.MaxValue, ErrorMessage = GlobalConstants.ValueInRange)]
        public int Price { get; set; }

        [MaxLength(GlobalConstants.LocationLength, ErrorMessage = GlobalConstants.MaxLength)]
        public string Location { get; set; }

        [Display(Name = GlobalConstants.DisplayName.UploadImages)]
        public ICollection<IFormFile> Images { get; set; }
    }


}
