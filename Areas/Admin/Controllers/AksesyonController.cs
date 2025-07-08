using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Repository.IRepository;
using Otobur.Models.Models;
using Otobur.Utility;

namespace Otobur.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_User}")]
    public class AksesyonController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private const int PageSize = 8;

        public AksesyonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string search, int page = 1)
        {
            IEnumerable<Aksesyon> objAksesyonList = _unitOfWork.Aksesyon.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                objAksesyonList = objAksesyonList
                    .Where(x => x.AksesyonNumarasi.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            int totalItems = objAksesyonList.Count();
            var pagedList = objAksesyonList
                .OrderBy(x => x.BitkininAdi)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            ViewBag.CurrentFilter = search;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / PageSize);

            return View(pagedList);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Aksesyon obj)
        {
            ModelState.Remove(nameof(Aksesyon.BitkiDurum));
            ModelState.Remove(nameof(Aksesyon.TohumBankasi));

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

                var bitkiDurum = new BitkiDurum
                {
                    AksesyonNumarasi = obj.AksesyonNumarasi,
                    BitkininAdi = obj.BitkininAdi
                };
                _unitOfWork.BitkiDurum.Add(bitkiDurum);

                var tohumBankasi = new TohumBankasi
                {
                    AksesyonNumarasi = obj.AksesyonNumarasi,
                    BitkininAdi = obj.BitkininAdi
                };
                _unitOfWork.TohumBankasi.Add(tohumBankasi);

                var herbaryum = new Herbaryum
                {
                    AksesyonNumarasi = obj.AksesyonNumarasi,
                    BitkininAdi = obj.BitkininAdi
                };
                _unitOfWork.Herbaryum.Add(herbaryum);

                _unitOfWork.Save();
                TempData["success"] = "Aksesyon başarıyla eklendi.";
                return RedirectToAction("Index");
            }
            ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return View(obj);
        }

        public IActionResult Edit(string id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Aksesyon obj)
        {
            ModelState.Remove(nameof(Aksesyon.BitkiDurum));
            ModelState.Remove(nameof(Aksesyon.TohumBankasi));

            if (ModelState.IsValid)
            {
                _unitOfWork.Aksesyon.Update(obj);

                var bitkiDurum = _unitOfWork.BitkiDurum.Get(b => b.AksesyonNumarasi == obj.AksesyonNumarasi);
                if (bitkiDurum != null)
                {
                    bitkiDurum.BitkininAdi = obj.BitkininAdi;
                    _unitOfWork.BitkiDurum.Update(bitkiDurum);
                }

                var tohumBankasi = _unitOfWork.TohumBankasi.Get(t => t.AksesyonNumarasi == obj.AksesyonNumarasi);
                if (tohumBankasi != null)
                {
                    tohumBankasi.BitkininAdi = obj.BitkininAdi;
                    _unitOfWork.TohumBankasi.Update(tohumBankasi);
                }

                var herbaryum = _unitOfWork.Herbaryum.Get(h => h.AksesyonNumarasi == obj.AksesyonNumarasi);
                if (herbaryum != null)
                {
                    herbaryum.BitkininAdi = obj.BitkininAdi;
                    _unitOfWork.Herbaryum.Update(herbaryum);
                }

                _unitOfWork.Save();

                TempData["success"] = "Aksesyon ve ilişkili kayıtlar başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

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