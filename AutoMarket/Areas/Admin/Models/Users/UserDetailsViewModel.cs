using AutoMarket.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Areas.Admin.Controllers
{
    public class UserDetailsViewModel
    {
        public string Id { get; set; }

        [Display(Name = GlobalConstants.DisplayName.Username)]
        public string Username { get; set; }

        [Display(Name = GlobalConstants.DisplayName.Email)]
        public string Email { get; set; }

        [Display(Name = GlobalConstants.DisplayName.RegistrationDate)]
        public string RegistrationDate { get; set; }

        [Display(Name = GlobalConstants.DisplayName.LockoutEnable)]
        public bool LockoutEnabled { get; set; }

        [Display(Name = GlobalConstants.DisplayName.LockoutEnd)]
        public DateTimeOffset? LockoutEnd{ get; set; }

        [Display(Name = GlobalConstants.DisplayName.TwoFactorAuth )]
        public bool TwoFactorEnabled { get; set; }

        [Display(Name = GlobalConstants.DisplayName.AccessFailedCount )]
        public int AccessFailedCount { get; set; }

        [Display(Name = GlobalConstants.DisplayName.VehicleOffersCount)]
        public int VehicleOffers { get; set; }

        [Display(Name = GlobalConstants.DisplayName.PartOffersCount)]
        public int PartOffers { get; set; }

    }
}
