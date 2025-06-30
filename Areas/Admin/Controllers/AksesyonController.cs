using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Data;
using Otobur.DataAccess.Repository.IRepository;
using Otobur.Models.Models;

namespace Otobur.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AksesyonController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;  
        public AksesyonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(string search)
        {
            IEnumerable<Aksesyon> objAksesyonList = _unitOfWork.Aksesyon.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                objAksesyonList = objAksesyonList
                    .Where(x => x.AksesyonNumarasi.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.CurrentFilter = search;
            return View(objAksesyonList.ToList());
        }
        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Aksesyon obj)
        {
            // Navigation property hatalarını temizle
            ModelState.Remove(nameof(Aksesyon.BitkiDurum));
            ModelState.Remove(nameof(Aksesyon.TohumBankasi));

            // EK: Aynı AksesyonNumarasi var mı kontrolü
            var existing = _unitOfWork.Aksesyon.Get(a => a.AksesyonNumarasi == obj.AksesyonNumarasi);
            if (existing != null)
            {   
                ModelState.AddModelError("AksesyonNumarasi", "Bu Aksesyon Numarası zaten mevcut.");
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View(obj);
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Aksesyon.Add(obj);

                // BitkiDurum için boş kayıt oluştur
                var bitkiDurum = new BitkiDurum
                {
                    AksesyonNumarasi = obj.AksesyonNumarasi,
                    // Diğer alanlar default/null bırakılır
                };
                _unitOfWork.BitkiDurum.Add(bitkiDurum);

                // TohumBankasi için boş kayıt oluştur
                var tohumBankasi = new TohumBankasi
                {
                    AksesyonNumarasi = obj.AksesyonNumarasi,
                    // Diğer alanlar default/null bırakılır
                };
                _unitOfWork.TohumBankasi.Add(tohumBankasi);

                // Herbaryum için boş kayıt oluştur
                var herbaryum = new Herbaryum
                {
                    AksesyonNumarasi = obj.AksesyonNumarasi,
                    // Diğer alanlar default/null bırakılır
                };
                _unitOfWork.Herbaryum.Add(herbaryum);

                _unitOfWork.Save();    
                TempData["success"] = "Aksesyon başarıyla eklendi.";
                return RedirectToAction("Index");
            }
            // Hataları ViewBag ile gönder
            ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return View(obj);
        }        

        // GET: Aksesyon/Edit/{id}
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Aksesyon? aksesyonFromDb = _unitOfWork.Aksesyon.Get(u => u.AksesyonNumarasi == id);
            //Aksesyon? obj = _aksesyonRepo.Aksesyonlar.FirstOrDefault(a => a.AksesyonNumarasi == id);
            //Aksesyon? AksesyonFromDb2 = _aksesyonRepo.Aksesyonlar.Where(a => a.AksesyonNumarasi == id).FirstOrDefault();

            //var aksesyon = _aksesyonRepo.Aksesyonlar.FirstOrDefault(a => a.AksesyonNumarasi == id);

            if (aksesyonFromDb == null)
            {
                return NotFound();
            }
            return View(aksesyonFromDb);
        }

        // POST: Aksesyon/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]  
        public IActionResult Edit(string id, Aksesyon obj)
        {
            ModelState.Remove(nameof(Aksesyon.BitkiDurum));
            ModelState.Remove(nameof(Aksesyon.TohumBankasi));

            if (ModelState.IsValid)
            {
                _unitOfWork.Aksesyon.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Aksesyon başarıyla güncellendi.";
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
            Aksesyon? aksesyonFromDb = _unitOfWork.Aksesyon.Get(u => u.AksesyonNumarasi == id);

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
            Aksesyon? obj = _unitOfWork.Aksesyon.Get(u => u.AksesyonNumarasi == id);  
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Aksesyon.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Aksesyon başarıyla silindi.";
            return RedirectToAction("Index");
        }
    }
}
