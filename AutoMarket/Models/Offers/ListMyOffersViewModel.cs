using System.Collections.Generic;


namespace AutoMarket.Models.Offers
{
    public class ListMyOffersViewModel : PagingViewModel
    {
        public ListMyOffersViewModel()
        {
            this.Offers = new List<MyOffersViewModel>();
        }
        public ICollection<MyOffersViewModel> Offers { get; set; }
    }
}
