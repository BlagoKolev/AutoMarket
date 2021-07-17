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

namespace AutoMarket.Controllers
{
    public class OffersController : Controller
    {
        private readonly IOffersService offerService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment environment;
        private readonly int ItemsPerPage = 9;

        public OffersController(IOffersService offersService, UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            this.offerService = offersService;
            this._userManager = userManager;
            this.environment = env;
        }

        [Authorize]
        public IActionResult Edit(int carId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Edit");
            }
            var currentUserId = _userManager.GetUserId(this.User);
            var editViewModel = offerService.GetVehicleToEdit(carId, currentUserId);
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
            return this.RedirectToAction(nameof(this.Details), new {carId = Id});
        }

        [Authorize]
        public IActionResult CreateVehicle()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateVehicle(CreateVehicleOfferViewModel input)
        {

            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Offers/CreateVehicle");
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

            return this.RedirectToAction("VehicleAll");
        }

        public IActionResult VehicleAll(int id = 1)
        {

            if (id <= 0)
            {
                id = 1;
            }

            var vehicleOffers = offerService.GetAllVehiclesOffers(id, ItemsPerPage);
            var itemsCount = offerService.GetItemsCount();

            var listAllVehicleViewModel = new ListAllVehicleViewModel
            {
                PageNumber = id,
                Cars = vehicleOffers,
                ItemsCount = itemsCount,
            };

            return this.View(listAllVehicleViewModel);
        }


        public IActionResult MyVehicleOffers(int id=1)
        {
            if (id <= 0)
            {
                id = 1;
            }

            var userId = this._userManager.GetUserId(this.User);
            var myVehiclesOffers = this.offerService.GetMyVehicleOffers(userId, id, ItemsPerPage);

            var listMyVehicleOffersViewModel = new ListMyVehicleViewModel
            {
                Cars = myVehiclesOffers,
                ItemsCount = myVehiclesOffers.Count,
                PageNumber = id,
            };

            return this.View(listMyVehicleOffersViewModel);
        }

        public IActionResult Details(int carId)
        {
            var currentOffer = this.offerService.GetVehicleOfferById(carId);
            return this.View(currentOffer);
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
