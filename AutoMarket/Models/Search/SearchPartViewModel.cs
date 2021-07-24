using AutoMarket.Data.Models.Enum;
using AutoMarket.Models.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models.Search
{
    public class SearchPartViewModel : ListPartsAllViewModel
    {
        public string Keyword { get; set; }
        public string Status { get; set; }
        
    }
}
