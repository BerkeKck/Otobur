﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Repository.IRepository;
using Otobur.Models.Models;
using Otobur.Utility;
using System.IO;

namespace Otobur.Views.Kullanici.Controllers
{
    [Area("Kullanici")]
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
            // Yıl bilgisini al
            var year = DateTime.Now.Year.ToString();

            // O yıla ait en büyük numarayı bul
            var last = _unitOfWork.Aksesyon
                .GetAll()
                .Where(a => a.AksesyonNumarasi.StartsWith(year + "-"))
                .OrderByDescending(a => a.AksesyonNumarasi)
                .FirstOrDefault();

            int nextNumber = 1;
            if (last != null)
            {
                var lastNumberPart = last.AksesyonNumarasi.Substring(5); // "YYYY-XXXXX"
                if (int.TryParse(lastNumberPart, out int parsed))
                {
                    nextNumber = parsed + 1;
                }
            }

            var newAksesyonNumarasi = $"{year}-{nextNumber.ToString("D5")}";
            var kullaniciAdi = User.Identity?.Name ?? "";
            var kullaniciKodu = User.Claims.FirstOrDefault(c => c.Type == "KullaniciKodu")?.Value ?? "";


            var model = new Aksesyon
            {
                AksesyonNumarasi = newAksesyonNumarasi,
                KullaniciAdi = kullaniciAdi,
                KullaniciKodu = kullaniciKodu
            };

            return View(model);
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
                    KullaniciAdi = obj.KullaniciAdi,
                    AksesyonNumarasi = obj.AksesyonNumarasi,
                    BitkininAdi = obj.BitkininAdi,
                    Lokasyon = obj.Lokasyon,
                    Koordinat = obj.Koordinat
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
                    herbaryum.KullaniciAdi = obj.KullaniciAdi;
                    herbaryum.BitkininAdi = obj.BitkininAdi;
                    herbaryum.Lokasyon = obj.Lokasyon;
                    herbaryum.Koordinat = obj.Koordinat;
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

        [HttpGet]
        public IActionResult PlantNameAutocomplete(string term)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "scientificName.txt");
            if (!System.IO.File.Exists(filePath))
                return Json(new List<string>());

            var allNames = System.IO.File.ReadAllLines(filePath);
            var suggestions = allNames
                .Where(name => name.Contains(term, StringComparison.OrdinalIgnoreCase))
                .Take(10)
                .ToList();

            return Json(suggestions);
        }

        [HttpGet]
        public async Task<IActionResult> BitkiAdiOner(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return Json(new List<string>());

            using var client = new HttpClient();
            var url = $"https://list.worldfloraonline.org/matching_rest.php?input_string={Uri.EscapeDataString(term)}&fuzzy_names=2";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return Json(new List<string>());

            var json = await response.Content.ReadAsStringAsync();
            using var doc = System.Text.Json.JsonDocument.Parse(json);

            var list = new List<string>();
            if (doc.RootElement.TryGetProperty("candidates", out var candidates))
            {
                foreach (var c in candidates.EnumerateArray())
                {
                    if (c.TryGetProperty("full_name_plain", out var name))
                        list.Add(name.GetString());
                }
            }
            // Ana eşleşmeyi de ekle
            if (doc.RootElement.TryGetProperty("match", out var match) && match.ValueKind == System.Text.Json.JsonValueKind.Object)
            {
                if (match.TryGetProperty("full_name_plain", out var mainName))
                {
                    var mainNameStr = mainName.GetString();
                    if (!string.IsNullOrWhiteSpace(mainNameStr) && !list.Contains(mainNameStr))
                        list.Insert(0, mainNameStr);
                }
            }
            return Json(list);
        }
    }
}