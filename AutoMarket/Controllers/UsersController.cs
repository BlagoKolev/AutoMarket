using AutoMarket.Data;
using AutoMarket.Data.Models;
using AutoMarket.Models.Users;
using AutoMarket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoMarket.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        public UsersController(IUsersService usersService)
        {

            this.usersService = usersService;
        }

        public IActionResult Details(string userId)
        {
            var user = usersService.GetUserById(userId);
            return this.View(user);
        }
        public IActionResult All(int id = 1)
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
                PageNumber = id,
                ItemsPerPage = GlobalConstants.ItemsPerPage,
                ItemsCount = usersService.GetUserAcountsCount(),
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
