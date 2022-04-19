using AutoMarket.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Models.Offers
{
    public class ListMyOffersViewModel : PagingViewModel
    {
        public ListMyOffersViewModel()
        {
            this.Offers = new List<MyOffersViewModel>();
        }
        public ICollection<MyOffersViewModel> Offers { get; set; }
        public ICollection<string> DealersList { get; set; }
        [Display(Name = GlobalConstants.DisplayName.Dealers)]
        public string DealerName { get; set; }
    }
}
