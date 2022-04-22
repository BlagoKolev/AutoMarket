using AutoMarket.Models.Home;
using System.Collections.Generic;

namespace AutoMarket.Services
{
    public interface IHomeService
    {
        List<int> GetAllOffersCount();
        ICollection<FeaturedVehiclesViewModel> GetFirstSixVehicleOffers();
    }
}
