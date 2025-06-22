using Microsoft.AspNetCore.Mvc;
using Otobur.Data; // DbContext i�in
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
        // Bitkinin ad� i�in navigation property ile birlikte �ekiyoruz
        var tohumlar = _db.TohumBankasi
            .Include(t => t.Aksesyon)
            .ToList();
        return View(tohumlar);
    }
}