using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using AutoMarket.Data;
using AutoMarket.Services;
using AutoMarket.Data.Models;
using AutoMarket.Models.Parts;

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

            if (listPartsAllViewModel.PageNumber > listPartsAllViewModel.PagesCount)
            {
                return this.Redirect($"{listPartsAllViewModel.PagesCount}");
            }

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

            return this.Redirect("/Offers/All");
        }

        public IActionResult Details(string offerId)
        {
            var detailsPartViewModel = partsService.GetDetails(offerId);
            return this.View(detailsPartViewModel);
        }

        private string GetUserId()
        {
            var userId = _userManager.GetUserId(this.User);
            return userId;
        }
    }
}
