using AutoMarket.Data;
using System;

namespace AutoMarket.Models
{
    public class PagingViewModel
    {
        public int PageNumber { get; set; } = GlobalConstants.DefaultPageNumber;
        public int ItemsCount { get; set; }
        public int ItemsPerPage { get; set; } = GlobalConstants.ItemsPerPage;
        public int PreviousPageNumber => this.PageNumber - 1;
        public int NextPageNumber => this.PageNumber + 1;
        public int PagesCount => (int)Math.Ceiling((double)this.ItemsCount / this.ItemsPerPage);
        public bool HasPrevious => this.PageNumber > 1;
        public bool HasNext => this.PageNumber < this.PagesCount;
    }
}
