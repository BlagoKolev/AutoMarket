using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace AutoMarket.Data.Models.Enum
{
    public enum EuroStandart
    {
        [Display(Name = "Euro 1")] [Description("Euro 1")] Euro_1 = 1,
        [Display(Name = "Euro 2")] [Description("Euro 2")] Euro_2 = 2,
        [Display(Name = "Euro 3")] [Description("Euro 3")] Euro_3 = 3,
        [Display(Name = "Euro 4")] [Description("Euro 4")] Euro_4 = 4,
        [Display(Name = "Euro 5")] [Description("Euro 5")] Euro_5 = 5,
        [Display(Name = "Euro 6")] [Description("Euro 6")] Euro_6 = 6
    }
}
