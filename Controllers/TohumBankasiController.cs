using Microsoft.AspNetCore.Mvc;
using Otobur.Data; // DbContext için
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class TohumBankasiController : Controller
{
    private readonly ApplicationDbContext _db;

    public TohumBankasiController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        // Bitkinin adý için navigation property ile birlikte çekiyoruz
        var tohumlar = _db.TohumBankasi
            .Include(t => t.Aksesyon)
            .ToList();
        return View(tohumlar);
    }
}