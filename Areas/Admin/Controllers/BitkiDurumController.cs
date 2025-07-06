using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Data;
using Otobur.DataAccess.Repository.IRepository;
using Otobur.Models.Models;
using Otobur.Utility;

namespace Otobur.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_User}")]
    public class BitkiDurumController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;  
        public BitkiDurumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(string search)
        {
            IEnumerable<BitkiDurum> objAksesyonList = _unitOfWork.BitkiDurum.GetAll();

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
        //public IActionResult Create(BitkiDurum obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.BitkiDurum.Add(obj);
        //        _unitOfWork.Save();    
        //        TempData["success"] = "BitkiDurum başarıyla eklendi.";
        //        return RedirectToAction("Index");
        //    }
        //    return View(obj);
        //}

        // GET: BitkiDurum/Edit/{id}
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            BitkiDurum? bitkiDurumFromDb = _unitOfWork.BitkiDurum.Get(u => u.AksesyonNumarasi == id);

            if (bitkiDurumFromDb == null)
            {
                return NotFound();
            }
            return View(bitkiDurumFromDb);
        }

        // POST: BitkiDurum/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, BitkiDurum obj)
        {
            // Navigation property hatalarını temizle
            ModelState.Remove(nameof(BitkiDurum.Aksesyon));

            if (id != obj.AksesyonNumarasi)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.BitkiDurum.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "BitkiDurum başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return View(obj);
        }

        // GET: BitkiDurum/Delete/{id}
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            BitkiDurum? bitkiDurumFromDb = _unitOfWork.BitkiDurum.Get(u => u.AksesyonNumarasi == id);

            if (bitkiDurumFromDb == null)
            {
                return NotFound();
            }
            return View(bitkiDurumFromDb);
        }
        // POST: BitkiDurum/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(string id)
        {
            BitkiDurum? obj = _unitOfWork.BitkiDurum.Get(u => u.AksesyonNumarasi == id);  
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.BitkiDurum.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "BitkiDurum başarıyla silindi.";
            return RedirectToAction("Index");
        }
    }
}
