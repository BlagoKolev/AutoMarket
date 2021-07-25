using Microsoft.AspNetCore.Mvc;

namespace AutoMarket.Controllers
{
    public class ErrorController : Controller
    {
       public IActionResult PageNotFound()
        {
            return this.View();
        }
       
    }
}
