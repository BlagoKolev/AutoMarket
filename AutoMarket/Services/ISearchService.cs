using AutoMarket.Models.Parts;
using AutoMarket.Models.Search;
using AutoMarket.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Services
{
    public interface ISearchService
    {
        ICollection<string> GetVehiclesMakes();
        ICollection<VehicleOffersAllViewModel> GetVehicleOffers(string make, string vehicleModel);
        ICollection<PartsAllViewModel> GetPartOffers(string keyword, string status);
    }
}
