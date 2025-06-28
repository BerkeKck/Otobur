using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Data;
using Otobur.DataAccess.Repository.IRepository;
using Otobur.Models.Models;

namespace Otobur.Controllers
{
    public class AksesyonController : Controller
    {
        private readonly IAksesyonRepository _aksesyonRepo;  
        public AksesyonController(IAksesyonRepository db)
        {
            _aksesyonRepo = db;
        }
        public IActionResult Index()
        {
            // Cast the result of _aksesyonRepo.GetAll() to IEnumerable<Aksesyon> before calling ToList()
            List<Aksesyon> objAksesyonList = _aksesyonRepo.GetAll().ToList();
            return View(objAksesyonList);
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
                _aksesyonRepo.Add(obj);
                _aksesyonRepo.Save();    
                TempData["success"] = "Aksesyon başarıyla eklendi.";
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
            Aksesyon? aksesyonFromDb = _aksesyonRepo.Get(u => u.AksesyonNumarasi == id);
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
            // Navigation property hatalarını temizle
            ModelState.Remove(nameof(Aksesyon.BitkiDurum));
            ModelState.Remove(nameof(Aksesyon.TohumBankasi));

            if (ModelState.IsValid)
            {
                _aksesyonRepo.Update(obj);
                _aksesyonRepo.Save();
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
            Aksesyon? aksesyonFromDb = _aksesyonRepo.Get(u => u.AksesyonNumarasi == id);

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
            Aksesyon? obj = _aksesyonRepo.Get(u => u.AksesyonNumarasi == id);  
            if (obj == null)
            {
                return NotFound();
            }
            _aksesyonRepo.Remove(obj);
            _aksesyonRepo.Save();
            TempData["success"] = "Aksesyon başarıyla silindi.";
            return RedirectToAction("Index");
        }
    }
}
