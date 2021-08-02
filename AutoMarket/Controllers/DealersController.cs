using Microsoft.AspNetCore.Mvc;
using AutoMarket.Data;
using AutoMarket.Services;
using AutoMarket.Models.Offers;

namespace AutoMarket.Controllers
{
    public class DealersController : Controller
    {
        private readonly IDealersService dealersService;
        public DealersController(IDealersService dealersService)
        {
            this.dealersService = dealersService;
        }
        public IActionResult All(string dealerName, int id = 1)
        {
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
    }
}
