using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
