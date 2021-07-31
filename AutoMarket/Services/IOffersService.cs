using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMarket.Models.Offers;
using AutoMarket.Models.Parts;


namespace AutoMarket.Services
{
    public interface IOffersService
    {
        Task UpdatePartOffer(EditPartOfferViewModel editedModel, string offerId, string userId,bool isUserAdmin);
        EditPartOfferViewModel GetPartToEdit(string offerId, string userId, bool isUserAdmin);
        PartDetailsViewModel GetPartDetails(string offerId); 
        ICollection<MyVehicleOffersViewModel> GetMyVehicleOffers(string userId, int id, int itemsPerPage);
        EditVehicleOfferViewModel GetVehicleToEdit(string carId, string userId, bool isUserAdmin);
        Task DeleteOffer(string offerId, string userId);
        Task UpdateVehicleOffer(EditVehicleOfferViewModel editedModel, string offerId, string userId, bool isUserAdmin);
        ICollection<MyOffersViewModel> GetAllUsersOffers(int id, string userId,int itemsPerPage);
        int GetAllUsersOffersCount(string userId);
        DetailsVehicleOfferViewModel GetVehicleOfferById(string carId);
        int GetItemsCount();
    }
}
