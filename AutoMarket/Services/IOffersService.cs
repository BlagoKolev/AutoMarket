using AutoMarket.Models.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Services
{
    public interface IOffersService
    {
        ICollection<MyVehicleOffersViewModel> GetMyVehicleOffers(string userId, int id, int itemsPerPage);
        EditVehicleOfferViewModel GetVehicleToEdit(string carId, string userId);
        void DeleteOffer(string offerId, string userId);
        void UpdateVehicleOffer(EditVehicleOfferViewModel editedModel, string offerId);
        ICollection<MyOffersViewModel> GetAllUsersOffers(int id, string userId,int itemsPerPage);
        int GetAllUsersOffersCount(string userId);
        DetailsVehicleOfferViewModel GetVehicleOfferById(string carId);
        int GetItemsCount();
    }
}
