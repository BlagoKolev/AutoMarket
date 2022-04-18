using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMarket.Data;
using AutoMarket.Data.Models;
using AutoMarket.Data.Models.Enum;


namespace AutoMarket.Models.Offers
{
    public class EditPartOfferViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [MaxLength(GlobalConstants.PhoneNumberLength, ErrorMessage = GlobalConstants.MaxLength)]
        public string Phone { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [MaxLength(GlobalConstants.TitleLength, ErrorMessage = GlobalConstants.MaxLength)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(GlobalConstants.DescriptionLength, ErrorMessage = GlobalConstants.MaxLength)]
        public string Description { get; set; }

        [Display(Name = GlobalConstants.DisplayName.Email)]
        [EmailAddress(ErrorMessage = GlobalConstants.ValidEmailFormat)]
        public string Email { get; set; }

        [Display(Name = GlobalConstants.DisplayName.PriceInEuro)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [Range(0, int.MaxValue, ErrorMessage = GlobalConstants.ValueInRange)]
        public int Price { get; set; }

        [MaxLength(GlobalConstants.LocationLength, ErrorMessage = GlobalConstants.MaxLength)]
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = GlobalConstants.DisplayName.VehicleType)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        public VehicleCategory VehicleType { get; set; }
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        public string Name { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        public PartCategory PartCategory { get; set; }

        [Display(Name = GlobalConstants.DisplayName.Condition)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        public PartStatus Status { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}

