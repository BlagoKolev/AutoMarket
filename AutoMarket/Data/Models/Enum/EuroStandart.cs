using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoMarket.Data.Models.Enum
{
    public enum EuroStandart
    {
        [Display(Name = "Евро 1")] Евро_1 = 1,
        [Display(Name = "Евро 2")] Евро_2 = 2,
        [Display(Name = "Евро 3")] Евро_3 = 3,
        [Display(Name = "Евро 4")] Евро_4 = 4,
        [Display(Name = "Евро 5")] Евро_5 = 5,
        [Display(Name = "Евро 6")] Евро_6 = 6
    }
}
