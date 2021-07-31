using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using AutoMarket.Data.Models;
using AutoMarket.Data;
using AutoMarket.Services;
using AutoMarket.Models.Offers;
using AutoMarket.Models.Vehicles;
using System.Threading.Tasks;

namespace AutoMarket.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehiclesService vehiclesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public VehiclesController(IVehiclesService vehiclesService, UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            this.vehiclesService = vehiclesService;
            this.userManager = userManager;
            this.environment = env;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateVehicleOfferViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Create));
            }

            var imagePath = $"{this.environment.WebRootPath}/images";
            var userId = this.userManager.GetUserId(this.User);

            try
            {
              await   vehiclesService.CreateVehicle(input, userId, imagePath);
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

            var vehicleOffers = vehiclesService.GetAllVehiclesOffers(id, GlobalConstants.ItemsPerPage);
            var itemsCount = vehiclesService.GetItemsCount();
            
            var listAllVehicleViewModel = new ListAllVehicleViewModel
            {
                PageNumber = id,
                Offers = vehicleOffers,
                ItemsCount = itemsCount,
            };

            if (listAllVehicleViewModel.PageNumber > listAllVehicleViewModel.PagesCount)
            {
                return this.Redirect($"{listAllVehicleViewModel.PagesCount}");
            }

            return this.View(listAllVehicleViewModel);
        }

        public IActionResult Details(string offerId)
        {
            var currentOffer = this.vehiclesService.GetVehicleOfferById(offerId);
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
