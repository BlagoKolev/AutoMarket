using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMarket.Models.Parts;
using AutoMarket.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMarket.Data;

namespace AutoMarket.Controllers
{
    public class PartsController : Controller
    {
        private readonly IPartsService partsService;
        public PartsController(IPartsService partsService)
        {
            this.partsService = partsService;
        }
        public IActionResult All(int id)
        {
            id = id <= 0 ? 1 : id;

            var partOffers = partsService.GelAllPartOffers(id, GlobalConstants.ItemsPerPage);
            var allOffersCount = partsService.GetAllPartsOffersCount();
            var listPartsAllViewModel = new ListPartsAllViewModel
            {
                PageNumber = id,
                ItemsCount = allOffersCount,
                Offers = partOffers
            };

            return this.View(listPartsAllViewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }
    }
}
