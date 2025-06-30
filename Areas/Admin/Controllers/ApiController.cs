using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Data;
using System.Linq;

namespace Otobur.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Api/[action]")]
    public class ApiController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AksesyonAutocomplete(string term)
        {
            var herbaryumluAksesyonlar = _context.HerbaryumDefteri.Select(h => h.AksesyonNumarasi).ToList();
            var result = _context.Aksesyonlar
                .Where(a => !herbaryumluAksesyonlar.Contains(a.AksesyonNumarasi) && a.AksesyonNumarasi.StartsWith(term))
                .Select(a => a.AksesyonNumarasi)
                .ToList();

            return Json(result);
        }

        [HttpGet]
        public IActionResult GetHerbaryumByAksesyon(string aksesyonNumarasi)
        {
            var herbaryum = _context.HerbaryumDefteri
                .FirstOrDefault(h => h.AksesyonNumarasi == aksesyonNumarasi);

            if (herbaryum == null)
                return Json(null);

            return Json(new
            {
                herbaryum.HerbaryumNo,
                herbaryum.BitkininAdi,
                herbaryum.KullaniciAdi,
                herbaryum.KullaniciKodu,
                herbaryum.KullaniciNumarasi,
                herbaryum.Lokasyon,
                herbaryum.Koordinat,
                herbaryum.Fotograf
            });
        }

        [HttpGet]
        public IActionResult GetBitkiDurumByAksesyon(string aksesyonNumarasi)
        {
            var bitkiDurum = _context.BitkiDurumu
                .FirstOrDefault(b => b.AksesyonNumarasi == aksesyonNumarasi);

            if (bitkiDurum == null)
                return Json(null);

            return Json(new
            {
                bitkiDurum.GozlemTarihi,
                bitkiDurum.BahcedeBulunduguYer,
                bitkiDurum.YerKodu,
                bitkiDurum.BitkininDurumu,
                bitkiDurum.VejetasyonDurumu,
                bitkiDurum.Gozlem
            });
        }

        [HttpGet]
        public IActionResult GetTohumBankasiByAksesyon(string aksesyonNumarasi)
        {
            var tohum = _context.TohumBankasi
                .FirstOrDefault(t => t.AksesyonNumarasi == aksesyonNumarasi);

            if (tohum == null)
                return Json(null);

            return Json(new
            {
                tohum.Miktar,
                tohum.BulunduguDolap
            });
        }
    }
}