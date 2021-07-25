using AutoMarket.Models.Parts;

namespace AutoMarket.Models.Search
{
    public class SearchPartViewModel : ListPartsAllViewModel
    {
        public string Keyword { get; set; }
        public string Status { get; set; }
        
    }
}
