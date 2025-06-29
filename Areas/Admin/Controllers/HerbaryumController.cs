using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Data; // DbContext için
using Otobur.DataAccess.Repository.IRepository;
using Otobur.Models.Models;
using System.Linq;

namespace Otobur.Areas.Admin.Controllers
{
    public class HerbaryumController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HerbaryumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Herbaryum> objHerbaryumList = _unitOfWork.Herbaryum.GetAll().ToList();
            return View(objHerbaryumList);
        }
        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Herbaryum obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Herbaryum.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Herbaryum başarıyla eklendi.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: Herbaryum/Edit/{id}
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Herbaryum? bitkiDurumFromDb = _unitOfWork.Herbaryum.Get(u => u.AksesyonNumarasi == id);

            if (bitkiDurumFromDb == null)
            {
                return NotFound();
            }
            return View(bitkiDurumFromDb);
        }

        // POST: Herbaryum/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Herbaryum obj)
        {
            // Navigation property hatalarını temizle
            ModelState.Remove(nameof(Herbaryum.AksesyonNumarasi));

            if (ModelState.IsValid)
            {
                _unitOfWork.Herbaryum.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Herbaryum başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }




        // GET: Herbaryum/Delete/{id}
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Herbaryum? bitkiDurumFromDb = _unitOfWork.Herbaryum.Get(u => u.AksesyonNumarasi == id);

            if (bitkiDurumFromDb == null)
            {
                return NotFound();
            }
            return View(bitkiDurumFromDb);
        }
        // POST: Herbaryum/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(string id)
        {
            Herbaryum? obj = _unitOfWork.Herbaryum.Get(u => u.AksesyonNumarasi == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Herbaryum.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Herbaryum başarıyla silindi.";
            return RedirectToAction("Index");
        }
    }
}
