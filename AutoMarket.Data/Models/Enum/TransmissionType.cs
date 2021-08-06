using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoMarket.Data.Models.Enum
{
    public enum TransmissionType
    {
        Automatic = 1,
        [Display(Name = " Semi-Automatic")] SemiAutomatic = 2,
        Manual = 3
    }
}
