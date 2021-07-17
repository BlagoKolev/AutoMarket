using AutoMarket.Data.Models;
using AutoMarket.Models.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Services
{
    public interface IOffersService
    {
        void UpdateVehicleOffer(EditVehicleOfferViewModel editedModel, int offerId);
        void CreateVehicle(CreateVehicleOfferViewModel offer, string userId, string imagePath);
        ICollection<VehicleOffersAllViewModel> GetAllVehiclesOffers(int id, int itemsPerPage);
        ICollection<MyVehicleOffersViewModel> GetMyVehicleOffers(string userId, int id, int itemsPerPage);
        DetailsOfferViewModel GetVehicleOfferById(int carId);
        EditVehicleOfferViewModel GetVehicleToEdit(int carId, string userId);
        int GetItemsCount();

    }
}
