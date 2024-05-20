using Microsoft.AspNetCore.Mvc;

namespace RestaurantSystem.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
