using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Data;
using System.Linq;

namespace Otobur.Areas.Admin.Controllers
{
    [Area("Admin")]
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