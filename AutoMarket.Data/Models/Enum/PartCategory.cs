using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoMarket.Data.Models.Enum
{
    public enum PartCategory
    {
        Двигател = 1,
        Трансмисия = 2,
        Филтри = 3,
        Окачване = 4,
        Ремъци = 5,
        Каросерия = 6,
        Ауспуси = 7,
        Консумaтиви = 8,
        Светлини = 9,
        [Display(Name = "Горивна система")] ГоривнаСистема = 10,
        [Display(Name = "Електрическа система")] ЕлектрическаСистема = 11,
        [Display(Name = "Запалителна система")] ЗапалителнаСистема = 12,
        [Display(Name = "Климатична система")] КлиматичнаСистема = 13,
        [Display(Name = "Кормилна система")] КормилнаСистема = 14,
        [Display(Name = "Охладителна система")] ОхладителнаСистема = 15,
        [Display(Name = "Спирачна система")] СпирачнаСистема = 16,
    }
}
