using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMarket.Services;
using AutoMarket.Data;
using AutoMarket.Models.Offers;
using static AutoMarket.Data.GlobalConstants;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AutoMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IOffersService offersService;

        public UsersController(IUsersService usersService, IOffersService offersService)
        {
            this.offersService = offersService;
            this.usersService = usersService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string userId)
        {
            var editModel = usersService.GetAccountByUserId(userId);
            return this.View(editModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(UserDetailsViewModel editedModel, string userId)
        {
            await usersService.EditUserInfo(userId, editedModel);

            TempData[GlobalConstants.AlertMessageKey] = GlobalConstants.EditAccountSuccessfully;

            return this.RedirectToAction(nameof(Details));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult All(string userId, int id = 1)
        {
            id = id <= 0 ? 1 : id;

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

        [Authorize(Roles = "Admin")]
        public IActionResult Details(string userId)
        {
            var user = usersService.GetAccountByUserId(userId);
            return this.View(user);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Accounts(int id = 1)
        {
            if (!this.User.IsInRole("Admin"))
            {
                return this.Redirect("Home/Index");
            }
            id = id <= 0 ? 1 : id;
            var userId = GetUserId();
            var usersAcountsList = this.usersService.GetUsersAcounts(userId, id, GlobalConstants.ItemsPerPage);

            var listUsersAllModel = new ListUsersAllViewModel
            {
                Users = usersAcountsList
            };
            return this.View(listUsersAllModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string userId)
        {
            await usersService.DeleteAccountById(userId);

            TempData[GlobalConstants.AlertMessageKey] = GlobalConstants.DeleteAccountSuccessfully;

            return this.RedirectToAction(nameof(Accounts));
        }
        private string GetUserId()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }
    }
}

