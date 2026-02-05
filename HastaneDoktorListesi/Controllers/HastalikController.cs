using HastaneBilgiListeleri.Models;
using HastaneBilgiListeleri.ViewModels;
using HastaneDoktorListesi.Data;
using HastaneDoktorListesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class HastalikController : Controller
{
    HastaneDBContext _context = new HastaneDBContext();

  
    public IActionResult HastalıkListesi()
    {
        var liste = _context.Hastaliklar.Include(h => h.Ilac).ToList();
        return View(liste);
    }

    [HttpGet]
    public IActionResult HastalıkEkle() {
        var vm = new HastalikEkle_VM
        {
            IlacListesi = _context.Ilaclar.Select(i => new SelectListItem
            {
                Value = i.IlacID.ToString(),
                Text = i.IlacAd
            }).ToList()
        };
        return View(vm);
    }

    [HttpPost]
    public IActionResult HastalıkEkle(Hastalik model)
    {
        if (!string.IsNullOrEmpty(model.HastalikAd))
        {
            var yeniHastalik = new Hastalik
            {
                HastalikAd = model.HastalikAd,
                IlacID = model.IlacID
            };
            _context.Hastaliklar.Add(model);
            _context.SaveChanges();
        }
        return RedirectToAction("HastalıkListesi");
    }

    [HttpGet]
    public IActionResult HastalıkGüncelle(int id)
    {
        var has = _context.Hastaliklar.Find(id);
        if (has == null) return NotFound();

        var vm = new HastalikEkle_VM
        {
            HastalikID = has.HastalikID,
            HastalikAd = has.HastalikAd,
            IlacID = has.IlacID,
            IlacListesi = _context.Ilaclar.Select(i => new SelectListItem
            {
                Value = i.IlacID.ToString(),
                Text = i.IlacAd
            }).ToList()
        };
        return View(vm);
    }


    [HttpPost]
    public IActionResult HastalıkGüncelle(HastalikEkle_VM model)
    {
        var guncellenecekHastalik = _context.Hastaliklar.Find(model.HastalikID);

        guncellenecekHastalik.HastalikAd = model.HastalikAd;
        guncellenecekHastalik.IlacID = model.IlacID;

        _context.SaveChanges();

        return RedirectToAction("HastalıkListesi");
            
        
    }

    public IActionResult HastalıkSil(int id)
    {
        var hastalık = _context.Hastaliklar.Find(id);
        if (hastalık != null)
        {
            _context.Hastaliklar.Remove(hastalık);
            _context.SaveChanges();
        }
        return RedirectToAction("HastalıkListesi");
    }
}