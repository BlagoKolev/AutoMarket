using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Data.Models.Enum
{
    public enum Color:int
    {
        Red = 1,
        Blue = 2,
        Green = 3,
        Yellow = 4,
        White = 5,
        Beige = 6,
        Burgundy = 7,
        Bronze = 8,
        Violet = 9,
        Cherry = 10,
        Graphite = 11,
        Gold = 12,
        Tiled = 13,
        Purple = 14,
        Metallic = 15,
        Orange = 16,
        Pearl = 17,
        [Display(Name = "Rose Ashes")] [Description("Rose Ashes")] RoseAshes = 18,
        Sand = 19,
        Pink = 20,
        Gray = 21,
        Black = 22,
        Chameleon = 23,
    }
}
