using AutoMarket.Models.Offers;
using AutoMarket.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AutoMarket.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using AutoMarket.Data;

namespace AutoMarket.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IOffersService offerService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment environment;

        public VehiclesController(IOffersService offersService, UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            this.offerService = offersService;
            this._userManager = userManager;
            this.environment = env;
        }

        [Authorize]
        public IActionResult Edit(int offerId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Edit");
            }
            var currentUserId = _userManager.GetUserId(this.User);
            var editViewModel = offerService.GetVehicleToEdit(offerId, currentUserId);
            return this.View(editViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(EditVehicleOfferViewModel editedModel, int Id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(editedModel);
            }
            offerService.UpdateVehicleOffer(editedModel, Id);
            return this.RedirectToAction(nameof(Details), new { carId = Id });
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateVehicleOfferViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Create));
            }

            var imagePath = $"{this.environment.WebRootPath}/images";
            var userId = this._userManager.GetUserId(this.User);

            try
            {
                offerService.CreateVehicle(input, userId, imagePath);
            }
            catch (Exception)
            {

                this.ModelState.AddModelError(string.Empty, "Image upload error");
                return this.View();
            }

            return this.RedirectToAction("All");
        }

        public IActionResult All(int id = 1)
        {
            id = id <= 0 ? 1 : id;

            var vehicleOffers = offerService.GetAllVehiclesOffers(id, GlobalConstants.ItemsPerPage);
            var itemsCount = offerService.GetItemsCount();

            var listAllVehicleViewModel = new ListAllVehicleViewModel
            {
                PageNumber = id,
                Offers = vehicleOffers,
                ItemsCount = itemsCount,
            };

            return this.View(listAllVehicleViewModel);
        }

        [Authorize]
        public IActionResult MyVehicleOffers(int id = 1)
        {
            if (id <= 0)
            {
                id = 1;
            }

            var userId = this._userManager.GetUserId(this.User);
            var myVehiclesOffers = this.offerService.GetMyVehicleOffers(userId, id, GlobalConstants.ItemsPerPage);
            var itemsCount = offerService.GetItemsCount();

            var listMyVehicleOffersViewModel = new ListMyVehicleViewModel
            {
                Offers = myVehiclesOffers,
                ItemsCount = itemsCount,
                PageNumber = id,
            };

            return this.View(listMyVehicleOffersViewModel);
        }

        public IActionResult Details(int offerId)
        {
            var currentOffer = this.offerService.GetVehicleOfferById(offerId);
            return this.View(currentOffer);
        }

        [Authorize]
        public IActionResult Delete(int offerId)
        {
            if (offerId != 0)
            {
                var userId = _userManager.GetUserId(this.User);
                offerService.DeleteOffer(offerId, userId);
            }
            return this.RedirectToAction(nameof(this.MyVehicleOffers));
        }
    }
    public class ManufactoringYearAttribute : ValidationAttribute
    {
        public ManufactoringYearAttribute(int minYear)
        {
            this.MinYear = minYear;
            this.ErrorMessage = $"Годината на производство трябва да бъде между {minYear} и {DateTime.UtcNow.Year}";
        }
        public int MinYear { get; }
        public override bool IsValid(object value)
        {
            if (value is int intValue)
            {
                if (intValue > DateTime.UtcNow.Year || intValue < this.MinYear)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
