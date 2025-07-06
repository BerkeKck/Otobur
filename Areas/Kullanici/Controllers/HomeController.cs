using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Repository.IRepository;
using Otobur.Models.Models;
using System.Diagnostics;

namespace Otobur.Areas.Kullanici.Controllers
{
    [Area("Kullanici")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            // Removed the 'includeProperties' parameter as it is not part of the method signature.  
            IEnumerable<Aksesyon> aksesyonList = _unitOfWork.Aksesyon.GetAll();
            return View(aksesyonList);
        }            
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

    