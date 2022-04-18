using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Data
{
    public class GlobalConstants
    {
        public const int ItemsPerPage = 9;
        public const int DefaultPageNumber = 1;
        public const int PhoneNumberLength = 15;
        public const int DescriptionLength = 5000;
        public const int LocationLength = 30;
        public const int TitleLength = 30;

        public const string VehicleImagePath = "/images/vehicles/";
        public const string PartImagePath = "/images/parts/";
        public const string AlertMessageKey = "AlertMessage";
        public const string DeleteSuccessfully = "You have successfully deleted your offer.";
        public const string UpdateOfferSuccessfully = "You have successfully updated your offer.";
        public const string BecomeDealerSuccessfully = "Congratulations! You are now a Dealer!";
        public const string CreateOfferSuccessfully = "You have successfully created а new offer.";
        public const string DeleteAccountSuccessfully = "Account successfully deleted.";
        public const string EditAccountSuccessfully = "Account successfully updated.";
        public const string DealerNameAllreadyExist = "Sorry! Dealer with that name already exists. Choose another name.";

        public const string Required = "The '{0}' field is required.";

        public class BecomeDealerErrorMessage
        {
            public const string CardHolderRegex = @"[A-Z a-z]+ [A-Z a-z]+";
            public const string CardHolderRegexErrorMsg = "The field must have the following format 'Name Last name'.";
            public const string CardNumberRegex = @"([0-9]{4}-){3}[0-9]{4}$";
            public const string CardNumberRegexErrorMsg = "Enter the 16-digit code from your card";
            public const string CardExpiredMonthRange = "'{0}' must be between {1} and {2}";
            public const string CardExpiredYearRange = "'{0}' must be between {1} and {2}";
            public const string CardSecurityCodeRegex = @"[0-9]{3}$";
            public const string CardSecurityCodeRegexErrorMsg = "Enter the 3-digit code from back side of your card";
        }

        public class DisplayName
        {
            public const string Email = "E-mail";
            public const string DealerName = "Dealer name";
            public const string CardHolder = "Card holder";
            public const string CardNumber = "Card number";
            public const string MonthOfExpiration = "Month of expiration";
            public const string YearOfExpiration = "Year of expiration";
            public const string SecurityCode = "Security code";


        }
    }
}
