using Microsoft.AspNetCore.Mvc;

namespace Otobur.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
