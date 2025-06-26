using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Otobur.Controllers
{
    public class BitkiDurumController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BitkiDurumController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var bitkiDurumList = _db.BitkiDurumu
                .Include(b => b.Aksesyon)
                .ToList();
            return View(bitkiDurumList);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}