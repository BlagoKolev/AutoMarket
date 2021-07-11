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

namespace AutoMarket.Controllers
{
    public class OffersController : Controller
    {
        private readonly IOffersService offerService;
        private readonly UserManager<ApplicationUser> _userManager;
        public OffersController(IOffersService offersService, UserManager<ApplicationUser> userManager)
        {
            this.offerService = offersService;
            this._userManager = userManager;
        }

        public IActionResult CreateVehicle()
        {
            return this.View();
        }

        [HttpPost]

        public IActionResult CreateVehicle(CreateVehicleOfferViewModel input)
        {

            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Offers/CreateVehicle");
            }

            var userId = this._userManager.GetUserId(this.User);
            offerService.CreateVehicle(input, userId);
            return this.RedirectToAction("VehicleAll");
        }

        public IActionResult VehicleAll()
        {
            var vehicleOffers = offerService.GetAllVehiclesOffers();
            return this.View(vehicleOffers);
        }


        public IActionResult MyVehicleOffers()
        {
            var userId = this._userManager.GetUserId(this.User);
            var myVehiclesOffers = this.offerService.GetMyVehicleOffers(userId);

            return this.View(myVehiclesOffers);
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
