using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using AutoMarket.Data;
using AutoMarket.Services;
using AutoMarket.Data.Models;
using AutoMarket.Models.Offers;

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

        public IActionResult All(int id = 1)
        {
            id = id <= 0 ? 1 : id;

            var userId = GetUserId();
            var allOffers = offersService.GetAllUsersOffers(id, userId, GlobalConstants.ItemsPerPage);
            var allUsersOffersCount = offersService.GetAllUsersOffersCount(userId);

            var listMyOffersViewModel = new ListMyOffersViewModel
            {
                Offers = allOffers,
                ItemsCount = allUsersOffersCount,
                PageNumber = id,
            };
            if (listMyOffersViewModel.PageNumber > listMyOffersViewModel.PagesCount)
            {
                return this.Redirect($"{listMyOffersViewModel.PagesCount}");
            }
            return this.View(listMyOffersViewModel);
        }

        [Authorize]
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
            var userId = GetUserId();
            offersService.UpdateVehicleOffer(editedModel, Id, userId);
            return this.RedirectToAction(nameof(VehicleDetails), new { offerId = Id });
        }

        [Authorize]
        public IActionResult PartDetails(string offerId)
        {
            var partDetailsModel = offersService.GetPartDetails(offerId);
            return this.View(partDetailsModel);
        }

        [Authorize]
        public IActionResult EditPart(string offerId)
        {
            var currentPartOffer = offersService.GetPartToEdit(offerId);
            return this.View(currentPartOffer);
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditPart(EditPartOfferViewModel editedModel, string Id)
        {
            if (!ModelState.IsValid)
            {
                return this.View(editedModel);
            }

            var userId = GetUserId();
            offersService.UpdatePartOffer(editedModel, Id, userId);
            return this.RedirectToAction(nameof(PartDetails), new { offerId = Id });
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
