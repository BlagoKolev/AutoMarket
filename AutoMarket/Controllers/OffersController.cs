using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Controllers
{
    public class OffersController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
