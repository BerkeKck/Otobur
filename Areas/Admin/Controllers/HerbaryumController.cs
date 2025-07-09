using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http; // Ekledik
using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Data; // DbContext için
using Otobur.DataAccess.Repository.IRepository;
using Otobur.Models.Models;
using Otobur.Utility;
using System.Linq;
using System.IO;
using Microsoft.IdentityModel.Tokens;

namespace Otobur.Views.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_User}")]
    public class HerbaryumController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HerbaryumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(string search)
        {
            // Aksesyon navigation property ile birlikte çek
            IEnumerable<Herbaryum> objAksesyonList = _unitOfWork.Herbaryum.GetAll(includeProperties: "Aksesyon");

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
            Herbaryum? herbaryumFromDb = _unitOfWork.Herbaryum.Get(
                u => u.AksesyonNumarasi == id,
                includeProperties: "Aksesyon"
            );

            if (herbaryumFromDb == null)
            {
                return NotFound();
            }
            return View(herbaryumFromDb);
        }

        // POST: Herbaryum/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Herbaryum obj, IFormFile? FotoDosya)
        {
            ModelState.Remove(nameof(Herbaryum.Aksesyon));

            if (id != obj.AksesyonNumarasi)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                // 1. Veritabanından mevcut nesneyi çek
                var herbaryumFromDb = _unitOfWork.Herbaryum.Get(
                    h => h.AksesyonNumarasi == obj.AksesyonNumarasi
                );

                if (herbaryumFromDb == null)
                    return NotFound();

                // 2. Alanları güncelle
                herbaryumFromDb.BitkininAdi = obj.BitkininAdi;
                herbaryumFromDb.KullaniciAdi = obj.KullaniciAdi;
                herbaryumFromDb.Lokasyon = obj.Lokasyon;
                herbaryumFromDb.Koordinat = obj.Koordinat;

                // Fotoğraf işlemleri
                if (FotoDosya != null && FotoDosya.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "herbaryum");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(FotoDosya.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        FotoDosya.CopyTo(stream);
                    }

                    herbaryumFromDb.Fotograf = $"/uploads/herbaryum/{fileName}";
                }

                // Otomatik Herbaryum No atama
                if (herbaryumFromDb.HerbaryumNo == null)
                {
                    var maxNo = _unitOfWork.Herbaryum
                        .GetAll()
                        .Where(h => h.HerbaryumNo != null)
                        .Select(h => h.HerbaryumNo.Value)
                        .DefaultIfEmpty(0)
                        .Max();

                    herbaryumFromDb.HerbaryumNo = maxNo + 1;
                }

                _unitOfWork.Herbaryum.Update(herbaryumFromDb);
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
            Herbaryum? herbaryumFromDb = _unitOfWork.Herbaryum.Get(
                u => u.AksesyonNumarasi == id,
                includeProperties: "Aksesyon"
            );

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
            Herbaryum? obj = _unitOfWork.Herbaryum.Get(u => u.AksesyonNumarasi == id, includeProperties: "Aksesyon");
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Herbaryum.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Herbaryum başarıyla silindi.";
            return RedirectToAction("Index");
        }

        // GET: Herbaryum/Defter
        public IActionResult Defter()
        {
            var herbaryumlar = _unitOfWork.Herbaryum.GetAll().Where(x => !string.IsNullOrEmpty(x.Fotograf)).ToList();
            return View(herbaryumlar);
        }
    }
}
