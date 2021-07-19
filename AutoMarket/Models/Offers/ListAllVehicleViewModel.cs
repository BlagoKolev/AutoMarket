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
            this.Offers = new List<VehicleOffersAllViewModel>();
        }
        public ICollection<VehicleOffersAllViewModel> Offers { get; set; }
    }
}
