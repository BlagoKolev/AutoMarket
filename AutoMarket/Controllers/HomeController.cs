using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using AutoMarket.Models;
using AutoMarket.Services;

namespace AutoMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService homeService;
        private readonly IMemoryCache memoryCache;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService, IMemoryCache memoryCache)
        {
            _logger = logger;
            this.homeService = homeService;
            this.memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            const string latestStatistics = "latestStatistics";

            var offersCount = this.memoryCache.Get<List<int>>(latestStatistics);

            if (offersCount == null)
            {
                offersCount = homeService.GetAllOffersCount();
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                this.memoryCache.Set(latestStatistics, offersCount, cacheOptions);
            }

            var firstSixOffers = homeService.GetFirstSixVehicleOffers();

            ViewBag.VehicleOffers = offersCount[0];
            ViewBag.PartOffers = offersCount[1];

            return View(firstSixOffers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
