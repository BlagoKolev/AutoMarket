using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Data.Models.Enum
{
    public enum TransmissionType
    {
        Automatic = 1,
        [Display(Name = "Semi-Automatic")]  [Description("Semi-Automatic")] SemiAutomatic = 2,
        Manual = 3
    }
}
