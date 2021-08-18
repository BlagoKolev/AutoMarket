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
    }
}
