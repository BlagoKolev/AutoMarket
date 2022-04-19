using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using AutoMarket.Data;
using AutoMarket.Data.Models;
using AutoMarket.Data.Models.Enum;

namespace AutoMarket.Models.Parts
{
    public class CreatePartViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [MaxLength(GlobalConstants.PhoneNumberLength, ErrorMessage = GlobalConstants.MaxLength)]
        public string Phone { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [MaxLength(GlobalConstants.TitleLength, ErrorMessage = GlobalConstants.MaxLength)]
        public string Title { get; set; }

        [MaxLength(GlobalConstants.DescriptionLength, ErrorMessage = GlobalConstants.MaxLength)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [EmailAddress(ErrorMessage = GlobalConstants.ValidEmailFormat)]
        [Display(Name = GlobalConstants.DisplayName.Email)]
        public string Email { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Range(0, int.MaxValue, ErrorMessage = GlobalConstants.ValueInRange)]
        [Display(Name = GlobalConstants.DisplayName.PriceInEuro)]
        public int Price { get; set; }

        [MaxLength(GlobalConstants.LocationLength, ErrorMessage = GlobalConstants.MaxLength)]
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Display(Name = GlobalConstants.DisplayName.VehicleType)]
        public VehicleCategory VehicleType { get; set; }
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        public string Name { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Display(Name = GlobalConstants.DisplayName.Category)]
        public PartCategory PartCategory { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Display(Name = GlobalConstants.DisplayName.Condition)]
        public PartStatus Status { get; set; }

        [Display(Name = GlobalConstants.DisplayName.UploadImages)]
        public ICollection<IFormFile> Images { get; set; }
    }
}
