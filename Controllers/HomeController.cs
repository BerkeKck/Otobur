using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Data;

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
