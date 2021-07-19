using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
