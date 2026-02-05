using HastaneBilgiListeleri.Models;
using HastaneDoktorListesi.Data;
using HastaneDoktorListesi.Models;
using Microsoft.AspNetCore.Mvc;

public class IlacController : Controller
{
    HastaneDBContext _context = new HastaneDBContext();

    public IActionResult IlacListesi() => View(_context.Ilaclar.ToList());

    [HttpGet]
    public IActionResult IlacEkle() => View();

    [HttpPost]
    public IActionResult IlacEkle(Ilac model)
    {
        if (!string.IsNullOrEmpty(model.IlacAd))
        {
            _context.Ilaclar.Add(model);
            _context.SaveChanges();
        }
        return RedirectToAction("IlacListesi");
    }

    [HttpGet]
    public IActionResult IlacGuncelle(int id)
    {
        var ilac = _context.Ilaclar.Find(id);
        if (ilac == null) return NotFound();
        return View(ilac);
    }

    [HttpPost]
    public IActionResult IlacGuncelle(Ilac model)
    {
        var ilac = _context.Ilaclar.Find(model.IlacID);
        if (ilac != null)
        {
            ilac.IlacAd = model.IlacAd;
            _context.SaveChanges();
        }
        return RedirectToAction("IlacListesi");
    }

    public IActionResult IlacSil(int id)
    {
        var ilac = _context.Ilaclar.Find(id);
        if (ilac != null)
        {
            _context.Ilaclar.Remove(ilac);
            _context.SaveChanges();
        }
        return RedirectToAction("IlacListesi");
    }
}