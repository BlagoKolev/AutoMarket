using AutoMarket.Models.Search;
using AutoMarket.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;
        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public IActionResult Vehicles(string make, string vehicleModel)
        {
            var makes = searchService.GetVehiclesMakes();
            var vehicleOffers = searchService.GetVehicleOffers(make,vehicleModel);
            var searchVehiclesModel = new SearchVehicleViewModel
            {
                Make = make,
                VehicleModel = vehicleModel,
                Makes = makes
            };
            return this.View(searchVehiclesModel);
        }

        public IActionResult VehiclesResult(string make, string vehicleModel)
        {
           
            return this.View();
        }
    }
}
