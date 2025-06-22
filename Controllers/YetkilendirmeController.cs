using Microsoft.AspNetCore.Mvc;
using Otobur.Data;
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
    }
}