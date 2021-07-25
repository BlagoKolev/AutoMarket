using AutoMarket.Data.Models.Enum;

namespace AutoMarket.Models.Parts
{
    public class PartsAllViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public PartCategory Category { get; set; }
        public PartStatus Status { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
