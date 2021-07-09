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
        void CreateVehicle(CreateVehicleOfferViewModel offer);
        ICollection<VehicleOffersAllViewModel> GetAllVehiclesOffers();
    }
}
