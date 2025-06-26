using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Data;
using System.Linq;

namespace Otobur.Controllers
{
    public class YetkilendirmeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public YetkilendirmeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var kullanicilar = _db.Kullanicilar.ToList();
            return View(kullanicilar);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}