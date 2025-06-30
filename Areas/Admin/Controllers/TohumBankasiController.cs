using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Data; // DbContext için
using Otobur.DataAccess.Repository.IRepository;
using Otobur.Models.Models;
using System.Linq;

namespace Otobur.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TohumBankasiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TohumBankasiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<TohumBankasi> objTohumBankasiList = _unitOfWork.TohumBankasi.GetAll().ToList();
            return View(objTohumBankasiList);
        }
        // CREATE işlemini iptal ettik.
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(TohumBankasi obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.TohumBankasi.Add(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "TohumBankasi başarıyla eklendi.";
        //        return RedirectToAction("Index");
        //    }
        //    return View(obj);
        //}

        // GET: TohumBankasi/Edit/{id}
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TohumBankasi? tohumBankasiFromDb = _unitOfWork.TohumBankasi.Get(u => u.AksesyonNumarasi == id);

            if (tohumBankasiFromDb == null)
            {
                return NotFound();
            }
            return View(tohumBankasiFromDb);
        }

        // POST: TohumBankasi/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, TohumBankasi obj)
        {
            // Navigation property hatalarını temizle
            ModelState.Remove(nameof(TohumBankasi.AksesyonNumarasi));

            if (ModelState.IsValid)
            {
                _unitOfWork.TohumBankasi.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "TohumBankasi başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }




        // GET: TohumBankasi/Delete/{id}
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TohumBankasi? tohumBankasiFromDb = _unitOfWork.TohumBankasi.Get(u => u.AksesyonNumarasi == id);

            if (tohumBankasiFromDb == null)
            {
                return NotFound();
            }
            return View(tohumBankasiFromDb);
        }
        // POST: TohumBankasi/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(string id)
        {
            TohumBankasi? obj = _unitOfWork.TohumBankasi.Get(u => u.AksesyonNumarasi == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.TohumBankasi.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "TohumBankasi başarıyla silindi.";
            return RedirectToAction("Index");
        }
    }
}
