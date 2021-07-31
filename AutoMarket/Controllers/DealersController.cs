using Microsoft.AspNetCore.Mvc;
using AutoMarket.Services;

namespace AutoMarket.Controllers
{
    public class DealersController : Controller
    {
        private readonly IDealersService dealersService;
        public DealersController(IDealersService dealersService)
        {
            this.dealersService = dealersService;
        }
        public IActionResult All()
        {
            var dealers = dealersService.GetAllDealers();
            return this.View(dealers);
        }
    }
}
