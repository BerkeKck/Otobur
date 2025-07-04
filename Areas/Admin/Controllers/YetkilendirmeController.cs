using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Otobur.DataAccess.Repository.IRepository;

namespace Otobur.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class YetkilendirmeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public YetkilendirmeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var kullaniciGrubu = HttpContext.Session.GetString("KullaniciGrubu");
            if (kullaniciGrubu != "Sistem Yöneticisi")
            {
                return RedirectToAction("Login", "Account", new { area = "Kullanici" });
            }
            var kullanicilar = _unitOfWork.Kullanici.GetAll().ToList();
            return View(kullanicilar);
        }

        // Diğer action'larda da aynı kontrolü yapın
    }
}