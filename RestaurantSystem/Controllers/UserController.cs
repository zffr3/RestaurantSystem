using Microsoft.AspNetCore.Mvc;

namespace RestaurantSystem.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
