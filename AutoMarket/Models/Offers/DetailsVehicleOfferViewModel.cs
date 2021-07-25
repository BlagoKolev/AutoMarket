using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMarket.Data.Models.Enum;


namespace AutoMarket.Models.Offers
{
    public class DetailsVehicleOfferViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Марка")]
        public string Make { get; set; }

        [Display(Name = "Модел")]
        public string Model { get; set; }

        [Display(Name = "Категория")]
        public BodyType BodyType { get; set; }

        [Display(Name = "Година на производство")]
        public int ManufacturingYear { get; set; }

        [Display(Name = "Обем на двигателя")]
        public decimal EngineCapacity { get; set; }

        [Display(Name = "Мощност к.с.")]
        public int HorsePower { get; set; }

        [Display(Name = "Двигател")]
        public EngineType EngineType { get; set; }

        [Display(Name = "Скоростна кутия")]
        public TransmissionType Transmission { get; set; }

        [Display(Name = "Пробег (км)")]
        public int Мileage { get; set; }

        [Display(Name = "Цвят")]
        public Color Color { get; set; }

        [Display(Name = "Екологичен клас")]
        public EuroStandart EuroStandart { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        public string Email { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        public int Price { get; set; }

        [Display(Name = "Населено място")]
        public string Location { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}

