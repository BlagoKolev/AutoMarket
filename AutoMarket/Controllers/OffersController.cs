using AutoMarket.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMarket.Data.Models;
using AutoMarket.Data;
using AutoMarket.Models.Offers;
using Microsoft.AspNetCore.Authorization;

namespace AutoMarket.Controllers
{
    public class OffersController : Controller
    {
        private readonly IOffersService offersService;
        private readonly UserManager<ApplicationUser> _userManager; 
        public OffersController(IOffersService offersService, UserManager<ApplicationUser> userManager)
        {
            this.offersService = offersService;
            this._userManager = userManager;
        }

        public IActionResult All(int id =1)
        {
            id = id <= 0 ? 1 : id;

            var userId = GetUserId();
            var allOffers = offersService.GetAllUsersOffers(id,userId,GlobalConstants.ItemsPerPage);
            var allUsersOffersCount = offersService.GetAllUsersOffersCount(userId);

            var listMyOffersViewModel = new ListMyOffersViewModel
            {
                Offers = allOffers,
                ItemsCount = allUsersOffersCount,
                PageNumber = id,
            };
            return this.View(listMyOffersViewModel);
        }

        [Authorize]
        //public IActionResult MyVehicleOffers(int id = 1)
        //{
        //    if (id <= 0)
        //    {
        //        id = 1;
        //    }

        //    var userId = this._userManager.GetUserId(this.User);
        //    var myVehiclesOffers = this.offersService.GetMyVehicleOffers(userId, id, GlobalConstants.ItemsPerPage);
        //    var itemsCount = offersService.GetItemsCount();

        //    var listMyVehicleOffersViewModel = new ListMyVehicleViewModel
        //    {
        //        Offers = myVehiclesOffers,
        //        ItemsCount = itemsCount,
        //        PageNumber = id,
        //    };

        //    return this.View(listMyVehicleOffersViewModel);
        //}
                    
    public IActionResult VehicleDetails(string offerId)
        {
            var currentOffer = this.offersService.GetVehicleOfferById(offerId);
            return this.View(currentOffer);
        }

        [Authorize]
        public IActionResult EditVehicle(string offerId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Edit");
            }
            var currentUserId = _userManager.GetUserId(this.User);
            var editViewModel = offersService.GetVehicleToEdit(offerId, currentUserId);
            return this.View(editViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditVehicle(EditVehicleOfferViewModel editedModel, string Id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(editedModel);
            }
            offersService.UpdateVehicleOffer(editedModel, Id);
            return this.RedirectToAction(nameof(VehicleDetails), new { offerId = Id });
        }

        [Authorize]
        public IActionResult Delete(string offerId)
        {
            if (offerId != null)
            {
                var userId = _userManager.GetUserId(this.User);
                offersService.DeleteOffer(offerId, userId);
            }
            return this.RedirectToAction(nameof(this.All));
        }

        private string GetUserId()
        {
            var userId = _userManager.GetUserId(this.User);
            return userId;
        }
    }
}
