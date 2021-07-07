using AutoMarket.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models.Offers
{
    public class CreateVehicleOfferViewModel : ValidationAttribute
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [Display(Name = "Марка")]
        public string Make { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        [Display(Name = "Модел")]
        public string Model { get; set; }

        [Required]
        public VehicleCategory VehicleCategory { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public BodyType BodyType { get; set; }

        [Required]
        [Range(1900, 2021)]
        [Display(Name = "Година на производство")]
        public int ManufacturingYear { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [Display(Name = "Кубатура на двигателя")]
        public decimal EngineCapacity { get; set; }

        [Range(0, 100000)]
        [Display(Name = "Мощност к.с.")]
        public int HorsePower { get; set; }

        [Required]
        [Display(Name = "Двигател")]
        public EngineType EngineType { get; set; }

        [Required]
        [Display(Name = "Скоростна кутия")]
        public TransmissionType Transmission { get; set; }

        [Display(Name = "Пробег (км)")]
        public int Мileage { get; set; }

        [Required]
        [Display(Name = "Цвят")]
        public Color Color { get; set; }

        [Required]
        [Display(Name = "Екологичен клас")]
        public EuroStandart EuroStandart { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [EmailAddress]
        [Display(Name = "Е-мейл")]
        public string Email { get; set; }

        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [Display(Name = "Населено място")]
        [MaxLength(30)]
        public string Location { get; set; }
    }
}
