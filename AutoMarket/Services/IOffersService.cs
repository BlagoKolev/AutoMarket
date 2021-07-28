using System.Collections.Generic;
using AutoMarket.Models.Offers;
using AutoMarket.Models.Parts;


namespace AutoMarket.Services
{
    public interface IOffersService
    {
        void UpdatePartOffer(EditPartOfferViewModel editedModel, string offerId, string userId,bool isUserAdmin);
        EditPartOfferViewModel GetPartToEdit(string offerId, string userId, bool isUserAdmin);
        PartDetailsViewModel GetPartDetails(string offerId); 
        ICollection<MyVehicleOffersViewModel> GetMyVehicleOffers(string userId, int id, int itemsPerPage);
        EditVehicleOfferViewModel GetVehicleToEdit(string carId, string userId, bool isUserAdmin);
        void DeleteOffer(string offerId, string userId);
        void UpdateVehicleOffer(EditVehicleOfferViewModel editedModel, string offerId, string userId, bool isUserAdmin);
        ICollection<MyOffersViewModel> GetAllUsersOffers(int id, string userId,int itemsPerPage);
        int GetAllUsersOffersCount(string userId);
        DetailsVehicleOfferViewModel GetVehicleOfferById(string carId);
        int GetItemsCount();
    }
}
