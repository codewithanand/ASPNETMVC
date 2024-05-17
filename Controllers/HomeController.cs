using Microsoft.AspNetCore.Mvc;

namespace BulkyMovie.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
