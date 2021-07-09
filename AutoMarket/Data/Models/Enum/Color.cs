using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoMarket.Data.Models.Enum
{
    public enum Color:int
    {
        Червен = 1,
        Син = 2,
        Зелен = 3,
        Жълт = 4,
        Бял = 5,
        Бежов = 6,
        Бордо = 7,
        Бронз = 8,
        Виолетов = 9,
        Вишнев = 10,
        Графит = 11,
        Златист = 12,
        Керемиден = 13,
        Лилав = 14,
        Металик = 15,
        Оранжев = 16,
        Перла = 17,
        [Display(Name = "Пепел от рози")] ПепелОтРози = 18,
        Пясъчен = 19,
        Розов = 20,
        Сив = 21,
        Черен = 22,
        Хамелеон = 23,
    }
}
