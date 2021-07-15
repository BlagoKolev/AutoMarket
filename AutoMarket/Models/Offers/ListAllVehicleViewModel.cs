using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models.Offers
{
    public class ListAllVehicleViewModel
    {
        public ListAllVehicleViewModel()
        {
            this.Cars = new List<VehicleOffersAllViewModel>();
        }
        public int PageNumber { get; set; } = 1;
        public int ItemsCount { get; set; }
        public int ItemsPerPage { get; set; } = 12;
        public int PreviousPageNumber => this.PageNumber - 1;
        public int NextPageNumber => this.PageNumber + 1;
        public int PagesCount => (int)Math.Ceiling((double)this.ItemsCount/this.ItemsPerPage);
        public bool HasPrevious => this.PageNumber > 1;
        public bool HasNext => this.PageNumber < this.PagesCount;
        public ICollection<VehicleOffersAllViewModel> Cars { get; set; }
    }
}
