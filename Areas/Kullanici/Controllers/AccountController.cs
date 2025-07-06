//using Microsoft.AspNetCore.Mvc;

//namespace Otobur.Areas.Kullanici.Controllers
//{
//    using Microsoft.AspNetCore.Mvc;
//    using Otobur.DataAccess.Repository.IRepository;
//    using Otobur.Models.Models;
//    using Microsoft.AspNetCore.Http;

//    [Area("Kullanici")]
//    public class AccountController : Controller
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public AccountController(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        // GET: /Account/Register
//        public IActionResult Register()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Register(Kullanici user)
//        {
//            if (_unitOfWork.Kullanici.Get(u => u.Eposta == user.Eposta) != null)
//            {
//                ModelState.AddModelError("Eposta", "Bu e-posta zaten kayıtlı.");
//                return View(user);
//            }
//            if (_unitOfWork.Kullanici.Get(u => u.KullaniciAdi == user.KullaniciAdi) != null)
//            {
//                ModelState.AddModelError("KullaniciAdi", "Bu kullanıcı adı zaten alınmış.");
//                return View(user);
//            }

//            if (ModelState.IsValid)
//            {
//                user.KullaniciNumarasi = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
//                user.KullaniciKodu = user.KullaniciKodu ?? user.KullaniciAdi.Substring(0, 2).ToUpper();

//                // Basit default roller
//                user.KullaniciGrubu = "Kullanici";
//                user.GorebilecegiTablolar = "Aksesyon,BitkiDurum";
//                user.KayitYapabilecegiTablolar = "Aksesyon";
//                user.KayitSilebilme = false;

//                _unitOfWork.Kullanici.Add(user);
//                _unitOfWork.Save();
//                TempData["success"] = "Kayıt başarılı!";
//                return RedirectToAction("Login");
//            }

//            return View(user);
//        }

//        // GET: /Account/Login
//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Login(string kullanici, string parola)
//        {
//            // kullanıcı adı veya e-posta ile giriş
//            var user = _unitOfWork.Kullanici.Get(u =>
//                (u.KullaniciAdi == kullanici || u.Eposta == kullanici) && u.Parola == parola);

//            if (user != null)
//            {
//                HttpContext.Session.SetString("KullaniciAdi", user.KullaniciAdi);
//                HttpContext.Session.SetString("KullaniciGrubu", user.KullaniciGrubu);
//                HttpContext.Session.SetString("KullaniciNumarasi", user.KullaniciNumarasi);
//                TempData["success"] = "Giriş başarılı!";

//                // Yönlendirme: Sistem Yöneticisi ise Admin area'ya, değilse Kullanici area'ya
//                if (user.KullaniciGrubu == "Sistem Yöneticisi")
//                {
//                    return RedirectToAction("Index", "Home", new { area = "Admin" });
//                }
//                else
//                {
//                    return RedirectToAction("Index", "Home", new { area = "Kullanici" });
//                }
//            }

//            ViewBag.Error = "Geçersiz kullanıcı adı/e-posta veya parola.";
//            return View();
//        }
            
//        public IActionResult Logout()
//        {
//            HttpContext.Session.Clear();
//            return RedirectToAction("Login");
//        }
//    }
//}