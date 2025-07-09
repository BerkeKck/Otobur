using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otobur.DataAccess.Repository.IRepository;
using Otobur.Utility;
using System.Linq.Dynamic.Core;
using System.Xml.Serialization;
using System.Text;

namespace Otobur.Views.Kullanici.Controllers
{
    [Area("Kullanici")]
    [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_User}")]
    public class VeritabaniController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VeritabaniController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string tablo, string aksesyon, string @operator)
        {
            IEnumerable<object> sonuc = new List<object>();

            if (!string.IsNullOrEmpty(tablo) && !string.IsNullOrEmpty(aksesyon))
            {
                switch (tablo)
                {
                    case "Aksesyon":
                        sonuc = _unitOfWork.Aksesyon.GetAll()
                            .Where(x => AksesyonFiltre(x.AksesyonNumarasi, aksesyon, @operator))
                            .ToList();
                        break;

                    case "BitkiDurum":
                        sonuc = _unitOfWork.BitkiDurum.GetAll() 
                            .Where(x => AksesyonFiltre(x.AksesyonNumarasi, aksesyon, @operator))
                            .ToList();
                        break;

                    case "Herbaryum":
                        sonuc = _unitOfWork.Herbaryum.GetAll()
                            .Where(x => AksesyonFiltre(x.AksesyonNumarasi, aksesyon, @operator))
                            .ToList();
                        break;

                    case "TohumBankasi":
                        sonuc = _unitOfWork.TohumBankasi.GetAll()
                            .Where(x => AksesyonFiltre(x.AksesyonNumarasi, aksesyon, @operator))
                            .ToList();
                        break;
                }

                ViewBag.Sonuc = sonuc;
            }

            return View();
        }

        private bool AksesyonFiltre(string value, string aranan, string operatorType)
        {
            if (string.IsNullOrEmpty(value)) return false;

            return operatorType switch
            {
                "StartsWith" => value.StartsWith(aranan, StringComparison.OrdinalIgnoreCase),
                "Contains" => value.Contains(aranan, StringComparison.OrdinalIgnoreCase),
                "Equals" => value.Equals(aranan, StringComparison.OrdinalIgnoreCase),
                _ => false,
            };
        }

        [HttpGet]
        public IActionResult ExportToXml(string tablo, string aksesyon, string @operator)
        {
            IEnumerable<object> sonuc = new List<object>();

            if (!string.IsNullOrEmpty(tablo) && !string.IsNullOrEmpty(aksesyon))
            {
                switch (tablo)
                {
                    case "Aksesyon":
                        sonuc = _unitOfWork.Aksesyon.GetAll()
                            .Where(x => AksesyonFiltre(x.AksesyonNumarasi, aksesyon, @operator))
                            .ToList();
                        break;
                    case "BitkiDurum":
                        sonuc = _unitOfWork.BitkiDurum.GetAll()
                            .Where(x => AksesyonFiltre(x.AksesyonNumarasi, aksesyon, @operator))
                            .ToList();
                        break;
                    case "Herbaryum":
                        sonuc = _unitOfWork.Herbaryum.GetAll()
                            .Where(x => AksesyonFiltre(x.AksesyonNumarasi, aksesyon, @operator))
                            .ToList();
                        break;
                    case "TohumBankasi":
                        sonuc = _unitOfWork.TohumBankasi.GetAll()
                            .Where(x => AksesyonFiltre(x.AksesyonNumarasi, aksesyon, @operator))
                            .ToList();
                        break;
                }
            }

            if (!sonuc.Any())
                return NotFound("No data to export.");

            // Determine the type for serialization
            Type listType = sonuc.First().GetType();
            var serializer = new XmlSerializer(typeof(List<>).MakeGenericType(listType));
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, sonuc);
            }

            var xmlBytes = Encoding.UTF8.GetBytes(sb.ToString());
            return File(xmlBytes, "application/xml", $"{tablo}_export.xml");
        }
    }
}
