using Microsoft.AspNetCore.Mvc;
using AutoMarket.Data;
using AutoMarket.Services;
using AutoMarket.Models.Offers;
using Microsoft.AspNetCore.Authorization;
using AutoMarket.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using AutoMarket.Models.Dealers;
using System.Security.Claims;

namespace AutoMarket.Controllers
{
    public class DealersController : Controller
    {
        private readonly IDealersService dealersService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public DealersController(IDealersService dealersService,
            IUsersService usersService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            this.dealersService = dealersService;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult All(string dealerName, int id = 1)
        {
            if (!signInManager.IsSignedIn(this.User))
            {
                return this.Redirect("/Identity/Account/Login?ReturnUrl=%2FDealers%2FAll");
            }

            id = id <= 0 ? 1 : id;
            var listMyOffersViewModel = new ListMyOffersViewModel
            {
                Offers = dealersService.GetDealersOffersByName(dealerName, id, GlobalConstants.ItemsPerPage),
                DealersList = dealersService.GetAllDealers(),
                PageNumber = id,
                ItemsCount = dealersService.GetOffersCount(dealerName),
                ItemsPerPage = GlobalConstants.ItemsPerPage
            };

            if (listMyOffersViewModel.PageNumber > listMyOffersViewModel.PagesCount && listMyOffersViewModel.PagesCount > 0)
            {
                return this.Redirect($"{listMyOffersViewModel.PagesCount}");
            }

            return this.View(listMyOffersViewModel);
        }

        [Authorize]
        public IActionResult BecomeDealer()
        {
            if (!this.User.IsInRole("Dealer") && !this.User.IsInRole("Admin"))
            {
                var userId = GetUserId();
                var user = dealersService.GetUserInfo(userId);
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

            var isDealerAlreadyExist = dealersService.IsDealerExist(dealerModel.DealerName);

            if (isDealerAlreadyExist)
            {
                return this.RedirectToAction(nameof(BecomeDealer));
            }

            var isValid = dealersService.MakeUserDealer(userId, dealerModel.DealerName);
            if (isValid.Result == false)
            {
                return BadRequest();
            }

            var user = await userManager.GetUserAsync(this.User);

            await signInManager.SignOutAsync();
            await signInManager.SignInAsync(user, false);
            return this.Redirect("/Home/Index/");
        }
        private string GetUserId()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }
    }
}
