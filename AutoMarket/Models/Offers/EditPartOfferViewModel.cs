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

        [Required(ErrorMessage = "The 'Phone' field is required.")]
        [MaxLength(GlobalConstants.PhoneNumberLength, ErrorMessage = "The 'Phone' field cannot be longer than 15 symbols")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The 'Title' field is required.")]
        [MaxLength(GlobalConstants.TitleLength, ErrorMessage = "The 'Title' field cannot be longer than 30 symbols")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [MaxLength(GlobalConstants.DescriptionLength, ErrorMessage = "The 'Description' field cannot be longer than 5000 symbols.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid E-mail form 'xxx@xxx.xx'.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The 'Price' field is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "The 'Price' must be between 0 и 2_147_483_647.")]
        [Display(Name = "Price (euro)")]
        public int Price { get; set; }

        [MaxLength(GlobalConstants.LocationLength, ErrorMessage = "The 'Location' field cannot be longer than 30 symbols")]
        [Display(Name = "Location")]
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Required(ErrorMessage = "The 'Vehicle type' field is required.")]
        [Display(Name = "Vehicle type")]
        public VehicleCategory VehicleType { get; set; }
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        [Required(ErrorMessage = "The 'Name' field is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The 'Category' field is required.")]
        [Display(Name = "Category")]
        public PartCategory PartCategory { get; set; }

        [Required(ErrorMessage = "The 'Condition' field is required.")]
        [Display(Name = "Condition")]
        public PartStatus Status { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}

