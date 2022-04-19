﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMarket.Data;
using AutoMarket.Data.Models.Enum;


namespace AutoMarket.Models.Offers
{
    public class EditVehicleOfferViewModel
    {
        public string Id { get; set; }

        [Display(Name = GlobalConstants.DisplayName.Brand)]
        public string Make { get; set; }

        public string Model { get; set; }

        [Display(Name = GlobalConstants.DisplayName.BodyType)]
        public BodyType BodyType { get; set; }

        [Display(Name = GlobalConstants.DisplayName.ManufacturingYear)]
        public int ManufacturingYear { get; set; }

        [Display(Name = GlobalConstants.DisplayName.EngineCapacity)]
        public decimal EngineCapacity { get; set; }

        [Display(Name = GlobalConstants.DisplayName.HorsePower)]
        public int HorsePower { get; set; }

        [Display(Name = GlobalConstants.DisplayName.EngineType)]
        public EngineType EngineType { get; set; }

        public TransmissionType Transmission { get; set; }

        [Display(Name = GlobalConstants.DisplayName.Mileage)]
        public int Мileage { get; set; }

        public Color Color { get; set; }

        [Display(Name = GlobalConstants.DisplayName.EuroStandart)]
        public EuroStandart EuroStandart { get; set; }

        public string Phone { get; set; }

        [Display(Name = GlobalConstants.DisplayName.Email)]
        public string Email { get; set; }

        public string Description { get; set; }

        [Display(Name = GlobalConstants.DisplayName.PriceInEuro)]
        public int Price { get; set; }

        public string Location { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
