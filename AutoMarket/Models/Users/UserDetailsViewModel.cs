using AutoMarket.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models.Users
{
    public class UserDetailsViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Registration date")]
        public string RegistrationDate { get; set; }

        [Display(Name = "Lockout enabled")]
        public bool LockoutEnabled { get; set; }

        [Display(Name = "Lockout end")]
        public DateTimeOffset? LockoutEnd{ get; set; }

        [Display(Name = "Two factor enabled")]
        public bool TwoFactorEnabled { get; set; }

        [Display(Name = "Access failed count")]
        public int AccessFailedCount { get; set; }

        [Display(Name = "Vehicles offers count")]
        public int VehicleOffers { get; set; }

        [Display(Name = "Part offers count")]
        public int PartOffers { get; set; }

    }
}
