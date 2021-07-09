using AutoMarket.Models.Offers;
using AutoMarket.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AutoMarket.Controllers
{
    public class OffersController : Controller
    {
        private readonly IOffersService offerService;
        public OffersController(IOffersService offersService)
        {
            this.offerService = offersService;
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

            //TODO GetUserId to pass below
            offerService.CreateVehicle(input);
            return this.RedirectToAction("VehicleAll");
        }

        public IActionResult VehicleAll()
        {
            var vehicleOffers = offerService.GetAllVehiclesOffers();
            return this.View(vehicleOffers);
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
