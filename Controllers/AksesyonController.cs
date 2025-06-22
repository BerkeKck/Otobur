using Microsoft.AspNetCore.Mvc;
using Otobur.Data;

namespace Otobur.Controllers
{
    public class AksesyonController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AksesyonController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<AksesyonDefteri> aksesyonList = _db.AksesyonNumarasi.ToList();
            return View(aksesyonList);
        }
        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Create(AksesyonDefteri obj)
        {
            if (ModelState.IsValid)
            {
                _db.AksesyonNumarasi.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
