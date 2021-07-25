using System.Collections.Generic;
using AutoMarket.Models.Offers;
using AutoMarket.Models.Parts;


namespace AutoMarket.Services
{
    public interface IOffersService
    {
        void UpdatePartOffer(EditPartOfferViewModel editedModel, string offerId, string userId);
        EditPartOfferViewModel GetPartToEdit(string offerId);
        PartDetailsViewModel GetPartDetails(string offerId); 
        ICollection<MyVehicleOffersViewModel> GetMyVehicleOffers(string userId, int id, int itemsPerPage);
        EditVehicleOfferViewModel GetVehicleToEdit(string carId, string userId);
        void DeleteOffer(string offerId, string userId);
        void UpdateVehicleOffer(EditVehicleOfferViewModel editedModel, string offerId, string userId);
        ICollection<MyOffersViewModel> GetAllUsersOffers(int id, string userId,int itemsPerPage);
        int GetAllUsersOffersCount(string userId);
        DetailsVehicleOfferViewModel GetVehicleOfferById(string carId);
        int GetItemsCount();
    }
}
