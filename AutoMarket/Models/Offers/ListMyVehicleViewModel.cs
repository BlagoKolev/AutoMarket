using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models.Offers
{
    public class ListMyVehicleViewModel : PagingViewModel
    {
        public ListMyVehicleViewModel()
        {
            this.Cars = new List<MyVehicleOffersViewModel>();
        }
        public ICollection<MyVehicleOffersViewModel> Cars { get; set; }
    }
}
