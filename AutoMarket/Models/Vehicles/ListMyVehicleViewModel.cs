using System.Collections.Generic;

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
