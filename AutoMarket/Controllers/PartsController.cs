using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMarket.Models.Parts;
using AutoMarket.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMarket.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AutoMarket.Data.Models;
using Microsoft.AspNetCore.Hosting;

namespace AutoMarket.Controllers
{
    public class PartsController : Controller
    {
        private readonly IPartsService partsService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _environment;
        public PartsController(IPartsService partsService, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            this.partsService = partsService;
            this._userManager = userManager;
            this._environment = environment;
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
        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreatePartViewModel formModel)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

            var imagePath = $"{this._environment.WebRootPath}/images";
            // var userId = this._userManager.GetUserId(this.User);
            var userId = GetUserId();

            try
            {
                partsService.CreatePartOffer(formModel, imagePath, userId);
            }
            catch (Exception)
            {

                this.ModelState.AddModelError(string.Empty, "Image upload error");
                return this.View();
            }

            return this.RedirectToAction(nameof(MyOffers));
        }

        [Authorize]
        public IActionResult MyOffers(int id = 1)
        {
            id = id <= 0 ? 1 : id;
            var userId = GetUserId();
            var usersParts = partsService.GetUsersParts(userId, id, GlobalConstants.ItemsPerPage);
            var partsCount = partsService.getUsersPartOffersCount(userId);

            var listMyPartsViewModel = new ListMyPartsViewModel
            {
                Offers = usersParts,
                PageNumber = id,
                ItemsCount = partsCount
            };

            return this.View(listMyPartsViewModel);
        }

        private string GetUserId()
        {
            var userId = _userManager.GetUserId(this.User);
            return userId;
        }
    }
}
