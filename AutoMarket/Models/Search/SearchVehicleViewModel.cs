using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMarket.Models.Vehicles;
using AutoMarket.Data;

namespace AutoMarket.Models.Search
{
    public class SearchVehicleViewModel : ListAllVehicleViewModel
    {
        [Display(Name = GlobalConstants.DisplayName.Brand)]
        public string Make { get; set; }
        [Display(Name = GlobalConstants.DisplayName.Model)]
        public string VehicleModel { get; set; }
        public ICollection<string> Makes { get; set; }
    }
}
