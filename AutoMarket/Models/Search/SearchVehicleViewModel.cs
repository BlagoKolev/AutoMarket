using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMarket.Models.Vehicles;

namespace AutoMarket.Models.Search
{
    public class SearchVehicleViewModel : ListAllVehicleViewModel
    {
        [Display(Name = "Brand")]
        public string Make { get; set; }
        [Display(Name = "Model")]
        public string VehicleModel { get; set; }
        public ICollection<string> Makes { get; set; }
    }
}
