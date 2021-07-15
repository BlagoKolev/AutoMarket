using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models.Offers
{
    public class ListAllVehicleViewModel : PagingViewModel
    {
        public ListAllVehicleViewModel()
        {
            this.Cars = new List<VehicleOffersAllViewModel>();
        }
        public ICollection<VehicleOffersAllViewModel> Cars { get; set; }
    }
}
