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
        [Display(Name ="Потребителско име")]
        public string Username { get; set; }

        [Display(Name = "Е-маил")]
        public string Email { get; set; }

        [Display(Name = "Дата на регистрация")]
        public string RegistrationDate { get; set; }

        [Display(Name = "Заключен профил")]
        public string LockoutEnabled { get; set; }

        [Display(Name = "Край на наказанието")]
        public DateTimeOffset? LockoutEnd{ get; set; }

        [Display(Name = "Двуфакторна аутентикация")]
        public string TwoFactorEnabled { get; set; }

        [Display(Name = "Брой неуспешни влизания")]
        public int AccessFailedCount { get; set; }

        [Display(Name = "Брой oбяви за автомобили")]
        public int VehicleOffers { get; set; }

        [Display(Name = "Брой oбяви за части")]
        public int PartOffers { get; set; }

    }
}
