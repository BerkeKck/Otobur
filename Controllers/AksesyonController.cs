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
            List<Aksesyon> aksesyonList = _db.Aksesyonlar.ToList();
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
            if (!ModelState.IsValid)
            {
                _db.Aksesyonlar.Add(obj);
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
            var aksesyon = _db.Aksesyonlar.FirstOrDefault(a => a.AksesyonNumarasi == id);
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
            // Navigation property hatalarını temizle
            ModelState.Remove(nameof(Aksesyon.BitkiDurum));
            ModelState.Remove(nameof(Aksesyon.TohumBankasi));

            if (id != obj.AksesyonNumarasi)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                ViewBag.Errors = errors;
                return View(obj);
            }

            var aksesyonFromDb = _db.Aksesyonlar.FirstOrDefault(a => a.AksesyonNumarasi == id);
            if (aksesyonFromDb == null)
            {
                return NotFound();
            }

            aksesyonFromDb.BitkininAdi = obj.BitkininAdi;
            aksesyonFromDb.MateryalCesidi = obj.MateryalCesidi;
            aksesyonFromDb.Koken = obj.Koken;
            aksesyonFromDb.Lokasyon = obj.Lokasyon;
            aksesyonFromDb.Koordinat = obj.Koordinat;
            aksesyonFromDb.ToplanmaTarihi = obj.ToplanmaTarihi;
            aksesyonFromDb.KullaniciAdi = obj.KullaniciAdi;
            aksesyonFromDb.KullaniciKodu = obj.KullaniciKodu;
            aksesyonFromDb.KullaniciNumarasi = obj.KullaniciNumarasi;

            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Aksesyon/Delete/{id}
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var aksesyonFromDb = _db.Aksesyonlar.Find(id);
            if (aksesyonFromDb == null)
            {
                return NotFound();
            }
            return View(aksesyonFromDb);
        }

        // POST: Aksesyon/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(string id)
        {
            var aksesyon = _db.Aksesyonlar.Find(id);
            if (aksesyon == null)
            {
                return NotFound();
            }
            _db.Aksesyonlar.Remove(aksesyon);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
