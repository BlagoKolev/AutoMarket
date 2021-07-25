using System.Collections.Generic;
using AutoMarket.Models.Offers;
using AutoMarket.Models.Vehicles;

namespace AutoMarket.Services
{
    public interface IVehiclesService
    {

        void CreateVehicle(CreateVehicleOfferViewModel offer, string userId, string imagePath);
        ICollection<VehicleOffersAllViewModel> GetAllVehiclesOffers(int id, int itemsPerPage);
        DetailsOfferViewModel GetVehicleOfferById(string offerId);
        int GetItemsCount();

    }
}
