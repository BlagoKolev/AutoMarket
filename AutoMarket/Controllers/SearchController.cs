using AutoMarket.Data;
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

        public IActionResult All(string make, string vehicleModel, int id = 1)
        {
            id = id <= 0 ? 1 : id;
            var makes = searchService.GetVehiclesMakes();
            var vehicleOffers = searchService.GetVehicleOffers(make, vehicleModel);
            var itemsCount = vehicleOffers.Count();
            var itemsPerPage = GlobalConstants.ItemsPerPage;
            //id = itemsCount <= itemsPerPage ? 1 : id;

            vehicleOffers = vehicleOffers
                .Skip((id - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

            var searchVehiclesModel = new SearchVehicleViewModel
            {
                Make = make,
                VehicleModel = vehicleModel,
                Makes = makes,
                Offers = vehicleOffers,
                PageNumber = id,
                ItemsCount = itemsCount,
            };
            return this.View(searchVehiclesModel);
        }

        public IActionResult Parts(string status, string keyword, int id = 1)
        {
            id = id <= 0 ? 1 : id;
            var partOffers = searchService.GetPartOffers(keyword, status);
            var itemsPerPage = GlobalConstants.ItemsPerPage;
            var itemsCount = partOffers.Count();
           // id = itemsCount <= itemsPerPage ? 1 : id;

            partOffers = partOffers
                .Skip((id - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

            var searchPartModel = new SearchPartViewModel
            {
                Keyword = keyword,
                Offers = partOffers,
                PageNumber = id,
                Status = status,
                ItemsCount = itemsCount
            };
            return this.View(searchPartModel);
        }
    }
}
