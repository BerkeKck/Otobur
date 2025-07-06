using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Data; // DbContext için
using Otobur.DataAccess.Repository.IRepository;
using Otobur.Models.Models;
using Otobur.Utility;
using System.Linq;

namespace Otobur.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_User}")]
    public class TohumBankasiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TohumBankasiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(string search)
        {
            IEnumerable<TohumBankasi> objAksesyonList = _unitOfWork.TohumBankasi.GetAll();

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
            ModelState.Remove(nameof(TohumBankasi.Aksesyon));

            if (id != obj.AksesyonNumarasi)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.TohumBankasi.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Tohum Bankası kaydı güncellendi.";
                return RedirectToAction("Index");
            }

            ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
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
