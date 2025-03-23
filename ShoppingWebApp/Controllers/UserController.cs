using Microsoft.AspNetCore.Mvc;

namespace ShoppingWebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            // User listesi burada alınıp listelenecek
            return View();
        }
    }
}
