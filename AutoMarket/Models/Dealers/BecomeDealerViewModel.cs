using System;
using System.ComponentModel.DataAnnotations;


namespace AutoMarket.Models.Dealers
{
    public class BecomeDealerViewModel
    {
        public string UserId { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "The 'E-mail' field is required.")]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Display(Name ="Dealer name")]
        [Required(ErrorMessage ="The 'Dealer name' field is required.")]
        public string DealerName { get; set; }

        [Required(ErrorMessage = "The 'Card holder' field is required.")]
        [Display(Name ="Card holder")]
        [RegularExpression(@"[A-Z a-z]+ [A-Z a-z]+", ErrorMessage = "The field must have the following format 'Name Last name'.")]
        public string CardHolder { get; set; }

        [Required(ErrorMessage = "The 'Card number' field is required.")]
        [Display(Name = "Card number")]
        [RegularExpression(@"([0-9]{4}-){3}[0-9]{4}$", ErrorMessage = "Enter the 16-digit code from your card")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "The 'Month of expiration' field is required.")]
        [Display(Name = "Month of expiration")]
        [Range(1, 12, ErrorMessage = "Month of expiration must be between 1 and 12")]
        public int CardExpiredMonth { get; set; }

        [Required(ErrorMessage = "The 'Year of expiration' field is required.")]
        [Display(Name = "Year of expiration")]
        [Range(2021,2024,ErrorMessage = "Year of expiration must be between 2021 and 2025")]
        public int CardExpiredYear { get; set; }

        [Required(ErrorMessage = "The 'Security code' field is required.")]
        [Display(Name = "Security code")]
        [RegularExpression(@"[0-9]{3}$", ErrorMessage = "Enter the 3-digit code from back side of your card")]
        public byte CVV { get; set; }
    }
}
