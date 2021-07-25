using System.Collections.Generic;
using AutoMarket.Models.Parts;
using AutoMarket.Models.Vehicles;


namespace AutoMarket.Services
{
    public interface ISearchService
    {
        ICollection<string> GetVehiclesMakes();
        ICollection<VehicleOffersAllViewModel> GetVehicleOffers(string make, string vehicleModel);
        ICollection<PartsAllViewModel> GetPartOffers(string keyword, string status);
    }
}
