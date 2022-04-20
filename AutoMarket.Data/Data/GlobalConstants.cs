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
        public const string MaxLength = "The '{0}' field cannot be longer than {1} symbols.";
        public const string ValidEmailFormat = "Please enter a valid E-mail form 'xxx@xxx.xx'.";
        public const string ValueInRange = "'{0}' must be between {1} and {2}";
        public const string StringInRange = "'{0}' must be between {2} and {1} symbols";

        public class BecomeDealerErrorMessage
        {
            public const string CardHolderRegex = @"[A-Z a-z]+ [A-Z a-z]+";
            public const string CardHolderRegexErrorMsg = "The field must have the following format 'Name Last name'.";
            public const string CardNumberRegex = @"([0-9]{4}-){3}[0-9]{4}$";
            public const string CardNumberRegexErrorMsg = "Enter the 16-digit code from your card";
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
            public const string Brand = "Brand";
            public const string BodyType = "Body type";
            public const string ManufacturingYear = "Manufacturing year";
            public const string EngineCapacity = "Engine capacity";
            public const string HorsePower = "Horse power";
            public const string EngineType = "Engine type";
            public const string Mileage = "Мileage (km)";
            public const string EuroStandart = "Euro standart";
            public const string VehicleType = "Vehicle type";
            public const string Condition = "Condition";
            public const string PriceInEuro = "Price (Euro)";
            public const string Dealers = "Dealers";
            public const string Category = "Category";
            public const string UploadImages = "Upload images";
            public const string Model = "Model";
            public const string Username = "Username";
            public const string RegistrationDate = "Registration date";
            public const string LockoutEnable = "Lockout enabled";
            public const string LockoutEnd = "Lockout end";
            public const string TwoFactorAuth = "Two factor enabled";
            public const string AccessFailedCount = "Access failed count";
            public const string VehicleOffersCount = "Vehicles offers count";
            public const string PartOffersCount = "Part offers count";
        }

        public class Seed
        {
            public const string VehicleDescription = "The car is in perfect condition. You will be very lucky if u buy it.";
            public const string TestEmail = "seed@mail.com";
            public const string TestPhone = "+359-896-663322";

            public class City
            {
                public const string Sofia = "Sofia";
                public const string Plovdiv = "Plovdiv";
                public const string Varna = "Varna";
                public const string StaraZagora = "Stara Zagora";
                public const string Rouse = "Rouse";
                public const string Burgas = "Burgas";
                public const string Pleven = "Pleven";
                public const string VelikoTarnovo = "Veliko Tarnovo";
            }
        }
    }
}
