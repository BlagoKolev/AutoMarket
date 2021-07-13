using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using AutoMarket.Controllers;
using AutoMarket.Data.Models.Enum;

namespace AutoMarket.Models.Offers
{
    public class CreateVehicleOfferViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето 'Марка' е задължително")]
        [StringLength(15, ErrorMessage = "Полето 'Марка' трябва да бъде между 3 и 15 символа.", MinimumLength = 3)]
        [Display(Name = "Марка")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Полето 'Модел' е задължително")]
        [StringLength(20, ErrorMessage = "Полето 'Модел' трябва да бъде между 1 и 20 символа.", MinimumLength = 1)]
        [Display(Name = "Модел")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public BodyType BodyType { get; set; }

        [Required(ErrorMessage = "Полето 'Година на производство' е задължително.")]
        [ManufactoringYear(1900)]
        [Display(Name = "Година на производство")]
        public int ManufacturingYear { get; set; }

        [Required(ErrorMessage = "Полето 'Обем на двигателя' е задължително.")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(typeof(decimal), "0.1", "1000000", ErrorMessage = "Обема на двигателя трябва да бъде между 0,1 и 1000000.")]
        [Display(Name = "Обем на двигателя")]
        public decimal EngineCapacity { get; set; }

        [Required(ErrorMessage = "Полето 'Мощност' е задължително.")]
        [Range(0, 100000, ErrorMessage = "Мощността трябва да бъде между 0 и 100000 к.с. .")]
        [Display(Name = "Мощност к.с.")]
        public int HorsePower { get; set; }

        [Required(ErrorMessage = "Полето 'Двигател' е задължително.")]
        [Display(Name = "Двигател")]
        public EngineType EngineType { get; set; }

        [Required(ErrorMessage = "Полето 'Скоростна кутия' е задължително.")]
        [Display(Name = "Скоростна кутия")]
        public TransmissionType Transmission { get; set; }


        [Required(ErrorMessage = "Полето 'Пробег' е задължително.")]
        [Display(Name = "Пробег (км)")]
        [Range(0, 2000000, ErrorMessage = "Пробегът трябва да е между 0 и 2 млн. километра.")]
        public int Мileage { get; set; }


        [Required(ErrorMessage = "Полето 'Цвят' е задължително.")]
        [Display(Name = "Цвят")]
        public Color Color { get; set; }


        [Required(ErrorMessage = "Полето 'Екологичен клас' е задължително.")]
        [Display(Name = "Екологичен клас")]
        public EuroStandart EuroStandart { get; set; }

        [Required(ErrorMessage = "Полето 'Телефон' е задължително.")]
        [MaxLength(15, ErrorMessage = "Полето 'Телефон' не може да е по-дълго от 15 символа")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Въведете валидна форма на Е-мейл 'xxx@xxx.xx'.")]
        [Display(Name = "Е-мейл")]
        public string Email { get; set; }

        [MaxLength(500, ErrorMessage = "Полето 'Описание' не може да бъде повече от 500 символа.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Полето 'Цена' е задължително.")]
        [Range(0, int.MaxValue, ErrorMessage = "Полето 'Цена' трябва да бъде между 0 и 2_147_483_647.")]
        [Display(Name = "Цена")]
        public int Price { get; set; }

        [MaxLength(30, ErrorMessage = "Полето 'Населено място' не трябва да бъде над 30 символа")]
        [Display(Name = "Населено място")]
        public string Location { get; set; }

        [Display(Name = "Качи снимка")]
        public ICollection<IFormFile> Images { get; set; }
    }


}
