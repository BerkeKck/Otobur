using Microsoft.AspNetCore.Mvc;
using Otobur.Data; // DbContext için
using System.Linq;

namespace Otobur.Controllers
{
    public class HerbaryumController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HerbaryumController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var herbaryumList = _db.HerbaryumDefteri.ToList();
            return View(herbaryumList);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
