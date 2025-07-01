using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Data; // DbContext için
using Otobur.DataAccess.Repository.IRepository;
using Otobur.Models.Models;
using System.Linq;

namespace Otobur.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HerbaryumController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HerbaryumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(string search)
        {
            IEnumerable<Herbaryum> objAksesyonList = _unitOfWork.Herbaryum.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                objAksesyonList = objAksesyonList
                    .Where(x => x.AksesyonNumarasi.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.CurrentFilter = search;
            return View(objAksesyonList.ToList());
        }
        // CREATE işlemini iptal ettik.
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Herbaryum obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Herbaryum.Add(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Herbaryum başarıyla eklendi.";
        //        return RedirectToAction("Index");
        //    }
        //    return View(obj);
        //}

        // GET: Herbaryum/Edit/{id}
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Herbaryum? herbaryumFromDb = _unitOfWork.Herbaryum.Get(u => u.AksesyonNumarasi == id);

            if (herbaryumFromDb == null)
            {
                return NotFound();
            }
            return View(herbaryumFromDb);
        }

        // POST: Herbaryum/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Herbaryum obj)
        {
            ModelState.Remove(nameof(Herbaryum.Aksesyon));

            if (id != obj.AksesyonNumarasi)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Herbaryum.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Herbaryum kaydı güncellendi.";
                return RedirectToAction("Index");
            }

            ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return View(obj);
        }

        // GET: Herbaryum/Delete/{id}
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Herbaryum? herbaryumFromDb = _unitOfWork.Herbaryum.Get(u => u.AksesyonNumarasi == id);

            if (herbaryumFromDb == null)
            {
                return NotFound();
            }
            return View(herbaryumFromDb);
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
