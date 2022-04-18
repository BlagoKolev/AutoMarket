using System;
using System.ComponentModel.DataAnnotations;
using AutoMarket.Data;


namespace AutoMarket.Models.Dealers
{
    public class BecomeDealerViewModel
    {
        public string UserId { get; set; }

        [Display(Name = GlobalConstants.DisplayName.Email)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Display(Name = GlobalConstants.DisplayName.DealerName)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        public string DealerName { get; set; }

        [Display(Name = GlobalConstants.DisplayName.CardHolder)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [RegularExpression(GlobalConstants.BecomeDealerErrorMessage.CardHolderRegex,
            ErrorMessage = GlobalConstants.BecomeDealerErrorMessage.CardHolderRegexErrorMsg)]
        public string CardHolder { get; set; }

        [Display(Name = GlobalConstants.DisplayName.CardNumber)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [RegularExpression(GlobalConstants.BecomeDealerErrorMessage.CardNumberRegex,
            ErrorMessage = GlobalConstants.BecomeDealerErrorMessage.CardNumberRegexErrorMsg)]
        public string CardNumber { get; set; }

        [Display(Name = GlobalConstants.DisplayName.MonthOfExpiration)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [Range(1, 12, ErrorMessage = GlobalConstants.BecomeDealerErrorMessage.CardExpiredMonthRange)]
        public int CardExpiredMonth { get; set; }

        [Display(Name = GlobalConstants.DisplayName.YearOfExpiration)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [Range(2022, 2025, ErrorMessage = GlobalConstants.BecomeDealerErrorMessage.CardExpiredYearRange)]
        public int CardExpiredYear { get; set; }

        [Display(Name = GlobalConstants.DisplayName.SecurityCode)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [RegularExpression(GlobalConstants.BecomeDealerErrorMessage.CardSecurityCodeRegex,
            ErrorMessage = GlobalConstants.BecomeDealerErrorMessage.CardSecurityCodeRegexErrorMsg)]
        public byte CVV { get; set; }
    }
}
