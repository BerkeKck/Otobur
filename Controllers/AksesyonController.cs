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
            List<Aksesyon> aksesyonList = _db.AksesyonNumarasi.ToList();
            return View(aksesyonList);
        }
        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Aksesyon obj)
        {
            if (ModelState.IsValid)
            {
                _db.AksesyonNumarasi.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: Aksesyon/Edit/{id}
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var aksesyon = _db.AksesyonNumarasi.FirstOrDefault(a => a.AksesyonNumarasi == id);
            if (aksesyon == null)
            {
                return NotFound();
            }
            return View(aksesyon);
        }

        // POST: Aksesyon/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Aksesyon obj)
        {
            if (id != obj.AksesyonNumarasi)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        // GET: Aksesyon/Delete/{id}
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var aksesyonFromDb = _db.AksesyonNumarasi.Find(id);
            if (aksesyonFromDb == null)
            {
                return NotFound();
            }
            return View(aksesyonFromDb);
        }

        // POST: Aksesyon/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(string id)
        {
            var aksesyon = _db.AksesyonNumarasi.Find(id);
            if (aksesyon == null)
            {
                return NotFound();
            }
            _db.AksesyonNumarasi.Remove(aksesyon);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
