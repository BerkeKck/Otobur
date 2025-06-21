using Microsoft.AspNetCore.Mvc;

namespace Otobur.Controllers
{
    public class HerbaryumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
