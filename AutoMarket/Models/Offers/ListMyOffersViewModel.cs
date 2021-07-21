using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
