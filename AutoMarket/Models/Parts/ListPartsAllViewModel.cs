using System.Collections.Generic;

namespace AutoMarket.Models.Parts
{
    public class ListPartsAllViewModel : PagingViewModel
    {
        public ListPartsAllViewModel()
        {
            this.Offers = new List<PartsAllViewModel>();
        }
        public ICollection<PartsAllViewModel> Offers { get; set; }
    }
}
