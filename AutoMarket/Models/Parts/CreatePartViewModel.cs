using AutoMarket.Data;
using AutoMarket.Data.Models;
using AutoMarket.Data.Models.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models.Parts
{
    public class CreatePartViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето 'Телефон' е задължително.")]
        [MaxLength(GlobalConstants.PhoneNumberLength, ErrorMessage = "Полето 'Телефон' не може да е по-дълго от 15 символа")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Полето 'Заглаие' е задължително")]
        [MaxLength(GlobalConstants.TitleLength, ErrorMessage = "Полето 'Заглавие' не трябва да е повече от 30 символа")]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [MaxLength(GlobalConstants.DescriptionLength, ErrorMessage = "Полето 'Описание' не може да бъде повече от 5000 символа.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [EmailAddress(ErrorMessage = "Въведете валидна форма на Е-мейл 'xxx@xxx.xx'.")]
        [Display(Name = "Е-мейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето 'Цена' е задължително.")]
        [Range(0, int.MaxValue, ErrorMessage = "Полето 'Цена' трябва да бъде между 0 и 2_147_483_647.")]
        [Display(Name = "Цена")]
        public int Price { get; set; }

        [MaxLength(GlobalConstants.LocationLength, ErrorMessage = "Полето 'Населено място' не трябва да бъде над 30 символа")]
        [Display(Name = "Населено място")]
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Required(ErrorMessage = "Полето 'Категория' е задължително.")]
        [Display(Name = "Категория превозно средство")]
        public VehicleCategory VehicleType { get; set; }
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        [Required(ErrorMessage = "Полето 'Наименование' е задължително")]
        [Display(Name = "Наименование на частта")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето 'Категория' е задължително")]
        [Display(Name = "Категория")]
        public PartCategory PartCategory { get; set; }

        [Required(ErrorMessage = "Полето 'Състояние' е задължително")]
        [Display(Name = "Състояние")]
        public PartStatus Status { get; set; }

        [Display(Name = "Добави снимка")]
        public ICollection<IFormFile> Images { get; set; }
    }
}
