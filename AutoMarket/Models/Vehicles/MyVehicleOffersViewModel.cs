using AutoMarket.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models.Offers
{
    public class MyVehicleOffersViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Марка")]
        public string Make { get; set; }

        [Display(Name = "Модел")]
        public string Model { get; set; }

        [Display(Name = "Цвят")]
        public Color Color { get; set; }

        [Display(Name = "Цена")]
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
