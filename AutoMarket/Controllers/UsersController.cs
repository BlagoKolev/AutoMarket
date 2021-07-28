using AutoMarket.Data;
using AutoMarket.Data.Models;
using AutoMarket.Models.Offers;
using AutoMarket.Models.Users;
using AutoMarket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace AutoMarket.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IOffersService offersService;
        public UsersController(IUsersService usersService, IOffersService offersService)
        {
            this.offersService = offersService;
            this.usersService = usersService;
        }

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
        public IActionResult Details(string userId)
        {
            var user = usersService.GetUserById(userId);
            return this.View(user);
        }
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
                //PageNumber = id,
                //ItemsPerPage = GlobalConstants.ItemsPerPage,
                //ItemsCount = usersService.GetUserAcountsCount(),
                Users = usersAcountsList
            };
            return this.View(listUsersAllModel);
        }

        private string GetUserId()
        {
            var adminId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return adminId;
        }
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@webmaster.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin@webmaster.com",
                    Email = "admin@webmaster.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "nimda").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
