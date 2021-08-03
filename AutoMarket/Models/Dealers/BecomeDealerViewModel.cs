using System;
using System.ComponentModel.DataAnnotations;


namespace AutoMarket.Models.Dealers
{
    public class BecomeDealerViewModel
    {
        public string UserId { get; set; }
        [Display(Name = "Е-мейл")]
        [Required(ErrorMessage = "Полето 'Е-мейл' е задължително")]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Display(Name ="Име на дилър")]
        [Required(ErrorMessage ="Полето 'Име на дилър' е задължително")]
        public string DealerName { get; set; }

        [Required(ErrorMessage = "Полето 'Име върху картата' е задължително.")]
        [Display(Name ="Име върху картата")]
        [RegularExpression(@"[A-Z a-z]+ [A-Z a-z]+", ErrorMessage = "Полето трябва да има следния формат 'Име Фамилия'")]
        public string CardHolder { get; set; }

        [Required(ErrorMessage = "Полето 'Номер на картата' е задължително.")]
        [Display(Name = "Номер на картата")]
        [RegularExpression(@"([0-9]{4}-){3}[0-9]{4}$", ErrorMessage = "Въведете 16 цифрения код на вашата карта")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Полето 'Месец на валидност' е задължително.")]
        [Display(Name = "Месец на валидност")]
        [Range(1, 12, ErrorMessage = "Месеца на валидност трябва да е между 1 и 12")]
        public int CardExpiredMonth { get; set; }

        [Required(ErrorMessage = "Полето 'Година на валидност' е задължително.")]
        [Display(Name = "Година на валидност")]
        [Range(2021,2024,ErrorMessage = "Годината на валидност трябва да е между 2021-2025")]
        public int CardExpiredYear { get; set; }

        [Required(ErrorMessage = "Полето 'Секюрити код' е задължително.")]
        [Display(Name = "Секюрити код")]
        [RegularExpression(@"[0-9]{3}$", ErrorMessage = "Въведете 3 цифрения секюрити код от гърба на вашата карта")]
        public byte CVV { get; set; }
    }
}
