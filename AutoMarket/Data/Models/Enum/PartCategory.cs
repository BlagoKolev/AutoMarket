using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoMarket.Data.Models.Enum
{
    public enum PartCategory
    {
        Двигател =1,
        Трансмисия =2,
        Филтри =3,
        Окачване =4,
        Ремъци =5,
        Каросерия = 6,
        Ауспуси =7,
        Консуламтиви =8,
        Светлини =9,
        [Description("Горивна система")] ГоривнаСистема = 10,
        [Description("Електрическа система")] ЕлектрическаСистема = 11,
        [Description("Запалителна система")] ЗапалителнаСистема = 12,
        [Description("Климатична система")] КлиматичнаСистема = 13,
        [Description("Кормилна система")] КормилнаСистема = 14,
        [Description("Охладителна система")] ОхладителнаСистема = 15,
        [Description("Спирачна система")] СпирачнаСистема = 16,
    }
}
