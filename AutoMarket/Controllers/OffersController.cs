using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using AutoMarket.Data;
using AutoMarket.Services;
using AutoMarket.Data.Models;
using AutoMarket.Models.Offers;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Controllers
{
    public class OffersController : Controller
    {
        private readonly IOffersService offersService;
        private readonly UserManager<ApplicationUser> userManager;
        public OffersController(IOffersService offersService, UserManager<ApplicationUser> userManager)
        {
            this.offersService = offersService;
            this.userManager = userManager;
        }

        [Authorize]
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

            if (listMyOffersViewModel.PageNumber > listMyOffersViewModel.PagesCount && listMyOffersViewModel.PagesCount > 0)
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
            var isUserAdmin = IsAdmin();
            var currentUserId = GetUserId();
            var editViewModel = offersService.GetVehicleToEdit(offerId, currentUserId, isUserAdmin);
            return this.View(editViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditVehicle(string offerId,EditVehicleOfferViewModel editedModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(editedModel);
            }
            var userId = GetUserId();
            var isUserAdmin = IsAdmin();
            await offersService.UpdateVehicleOffer(editedModel, offerId, userId, isUserAdmin);
            return this.RedirectToAction(nameof(VehicleDetails), new { offerId = offerId });
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
            var userId = GetUserId();
            var isUserAdmin = IsAdmin();
            var currentPartOffer = offersService.GetPartToEdit(offerId, userId, isUserAdmin);
            return this.View(currentPartOffer);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditPart(string offerId,EditPartOfferViewModel editedModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(editedModel);
            }

            var userId = GetUserId();
            var isUserAdmin = IsAdmin();
            await offersService.UpdatePartOffer(editedModel, offerId, userId, isUserAdmin);
            return this.RedirectToAction(nameof(PartDetails), new { offerId = offerId });
        }

        [Authorize]
        public IActionResult Delete(string offerId)
        {
            if (offerId != null)
            {
                var isUserAdmin = IsAdmin();
                var userId = userManager.GetUserId(this.User);
                offersService.DeleteOffer(offerId, userId, isUserAdmin);
            }
            return this.RedirectToAction(nameof(this.All));
        }

        private bool IsAdmin()
        {
            return this.User.IsInRole("Admin");
        }
        private string GetUserId()
        {
            var userId = userManager.GetUserId(this.User);
            return userId;
        }
    }
}
