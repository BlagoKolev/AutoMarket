using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using AutoMarket.Data;
using AutoMarket.Services;
using AutoMarket.Data.Models;
using AutoMarket.Models.Offers;
using AutoMarket.Models.Users;

namespace AutoMarket.Controllers
{

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IOffersService offersService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        public UsersController(IUsersService usersService,
            IOffersService offersService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.offersService = offersService;
            this.usersService = usersService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult BecomeDealer()
        {
            if (!this.User.IsInRole("Dealer") && !this.User.IsInRole("Admin"))
            {
                var userId = GetUserId();
                var user = usersService.GetUserInfo(userId);
                return this.View(user);
            }
            return this.Redirect("/Home/Index/");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> BecomeDealer(BecomeDealerViewModel dealerModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(BecomeDealer));
            }
            
            var userId = GetUserId();

            var isDealerAlreadyExist = usersService.IsDealerExist(dealerModel.DealerName);

            if (isDealerAlreadyExist)
            {
                return this.RedirectToAction(nameof(BecomeDealer));
            }

            var isValid = usersService.MakeUserDealer(userId, dealerModel.DealerName);
            if (isValid.Result == false)
            {
                return BadRequest();
            }

            var user = await userManager.GetUserAsync(this.User);

            await signInManager.SignOutAsync();
            await signInManager.SignInAsync(user, false);
            return this.Redirect("/Home/Index/");
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
            var user = usersService.GetUserById(userId);
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
                //PageNumber = id,
                //ItemsPerPage = GlobalConstants.ItemsPerPage,
                //ItemsCount = usersService.GetUserAcountsCount(),
                Users = usersAcountsList
            };
            return this.View(listUsersAllModel);
        }

        private string GetUserId()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }
    }


}
