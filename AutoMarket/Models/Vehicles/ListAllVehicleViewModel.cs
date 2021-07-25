using System.Collections.Generic;

namespace AutoMarket.Models.Vehicles
{
    public class ListAllVehicleViewModel : PagingViewModel
    {
        public ListAllVehicleViewModel()
        {
            this.Offers = new List<VehicleOffersAllViewModel>();
        }
        public ICollection<VehicleOffersAllViewModel> Offers { get; set; }
    }
}
