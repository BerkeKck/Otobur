using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Data;

namespace Otobur.Areas.Kullanici.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
