using System.Collections.Generic;

namespace AutoMarket.Models.Parts
{
    public class ListMyPartsViewModel : PagingViewModel
    {
        public ListMyPartsViewModel()
        {
            this.Offers = new List<MyPartsViewModel>();
        }
        public ICollection<MyPartsViewModel> Offers { get; set; }
    }
}
