using Microsoft.AspNetCore.Mvc;

namespace Otobur.Areas.Kullanici.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Otobur.DataAccess.Repository.IRepository;
    using Otobur.Models.Models;

    [Area("Kullanici")]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Kullanici user)
        {
            if (_unitOfWork.Kullanici.Get(u => u.Eposta == user.Eposta) != null)
            {
                ModelState.AddModelError("Eposta", "Bu e-posta zaten kayıtlı.");
                return View(user);
            }

            if (ModelState.IsValid)
            {
                user.KullaniciNumarasi = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
                user.KullaniciKodu = user.KullaniciAdi.Substring(0, 2).ToUpper();

                // basit default roller
                user.KullaniciGrubu = "Kullanici";
                user.GorebilecegiTablolar = "Aksesyon,BitkiDurum";
                user.KayitYapabilecegiTablolar = "Aksesyon";
                user.KayitSilebilme = false;

                _unitOfWork.Kullanici.Add(user); 
                _unitOfWork.Save();
                TempData["success"] = "Kayıt başarılı!";
                return RedirectToAction("Login");
            }

            return View(user);
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string eposta, string parola)
        {
            var user = _unitOfWork.Kullanici.Get(u => u.Eposta == eposta && u.Parola == parola);

            if (user != null)
            {
                HttpContext.Session.SetString("KullaniciAdi", user.KullaniciAdi);
                HttpContext.Session.SetString("KullaniciGrubu", user.KullaniciGrubu);
                HttpContext.Session.SetString("KullaniciNumarasi", user.KullaniciNumarasi);
                TempData["success"] = "Giriş başarılı!";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Geçersiz e-posta veya parola.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}