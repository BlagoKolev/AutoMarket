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
            this.Offers = new List<MyVehicleOffersViewModel>();
        }
        public ICollection<MyVehicleOffersViewModel> Offers { get; set; }
    }
}
