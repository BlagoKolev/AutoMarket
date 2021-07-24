using AutoMarket.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models.Search
{
    public class SearchVehicleViewModel : ListAllVehicleViewModel
    {
        [Display(Name = "Марка")]
        public string Make { get; set; }
        [Display(Name = "Модел")]
        public string VehicleModel { get; set; }
        public ICollection<string> Makes { get; set; }
    }
}
