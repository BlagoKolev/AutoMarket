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
        void CreateVehicle(CreateVehicleOfferViewModel offer, string userId, string imagePath);
        ICollection<VehicleOffersAllViewModel> GetAllVehiclesOffers(int id, int itemsPerPage);
        ICollection<MyVehicleOffersViewModel> GetMyVehicleOffers(string userId);
        DetailsOfferViewModel GetVehicleOfferById(int carId);
        int GetItemsCount();

    }
}
