using HastaneDoktorListesi.Data;
using HastaneDoktorListesi.Models;
using HastaneDoktorListesi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HastaneDoktorListesi.Controllers
{
    public class HastaController : Controller
    {
        HastaneDBContext _context = new HastaneDBContext();
        public IActionResult Index()
        {
            _context.Database.EnsureCreated();
            return View();
        }

        public IActionResult HastaListesi()
        {
            var hastalar = _context.Hastalar.Include(h => h.Doktor).Include(h => h.Hastalık) .ThenInclude(has => has.Ilac).ToList();

            return View(hastalar);
        }
        [HttpGet]
        public IActionResult HastaEkle()
        {
            var vm = new HastaEkle_VM
            {
                DoktorListesi = _context.Doktorlar.Select(d => new SelectListItem
                {
                    Value = d.DoktorID.ToString(),
                    Text = d.DoktorAdi
                }).ToList(),

                HastalikListesi = _context.Hastaliklar.Select(h => new SelectListItem
                {
                    Value = h.HastalikID.ToString(),
                    Text = h.HastalikAd
                }).ToList()
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult HastaEkle(HastaEkle_VM model)
        {
            string dosyaAdi = "default.png";
            if (model.HastaProfilResmi != null)
            {
                dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(model.HastaProfilResmi.FileName);
                string yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/HastaProfilePic", dosyaAdi);
                using (var stream = new FileStream(yol, FileMode.Create)) { model.HastaProfilResmi.CopyTo(stream); }
            }

            var yeniHasta = new Hasta
            {
                HastaAd = model.HastaAd,
                HastaProfilResmi = dosyaAdi,
                DoktorID = model.DoktorID,
                HastalıkID = model.HastalıkID
            };

            _context.Hastalar.Add(yeniHasta);
            _context.SaveChanges();
            return RedirectToAction("HastaListesi");
        }

        [HttpGet]
        public IActionResult HastaGuncelle(int id)
        {
            var hasta = _context.Hastalar.Find(id);
            if (hasta == null) return NotFound();

            var vm = new HastaEkle_VM
            {
                HastaID = hasta.HastaID,
                HastaAd = hasta.HastaAd,
                DoktorID = hasta.DoktorID,
                HastalıkID = hasta.HastalıkID,

                HastalikListesi = _context.Hastaliklar.Select(h => new SelectListItem
                {
                    Value = h.HastalikID.ToString(),
                    Text = h.HastalikAd
                }).ToList(),

                DoktorListesi = _context.Doktorlar.Select(d => new SelectListItem
                {
                    Value = d.DoktorID.ToString(),
                    Text = d.DoktorAdi
                }).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult HastaGuncelle(HastaEkle_VM model)
        {
            
            if (model.HastaProfilResmi == null)
            {
                ModelState.Remove("HastaProfilResmi");
            }

            if (ModelState.IsValid)
            {
                var guncellenecek = _context.Hastalar.Find(model.HastaID);
                if (guncellenecek != null)
                {
                    guncellenecek.HastaAd = model.HastaAd;
                    guncellenecek.DoktorID = model.DoktorID;
                    guncellenecek.HastalıkID = model.HastalıkID;

                    
                    if (model.HastaProfilResmi != null)
                    {
                        string dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(model.HastaProfilResmi.FileName);
                        string yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/HastaProfilePic", dosyaAdi);
                        using (var stream = new FileStream(yol, FileMode.Create))
                        {
                            model.HastaProfilResmi.CopyTo(stream);
                        }
                        guncellenecek.HastaProfilResmi = dosyaAdi;
                    }

                    _context.SaveChanges();
                    return RedirectToAction("HastaListesi");
                }
            }

           
            model.HastalikListesi = _context.Hastaliklar.Select(h => new SelectListItem
            {
                Value = h.HastalikID.ToString(),
                Text = h.HastalikAd
            }).ToList();

            model.DoktorListesi = _context.Doktorlar.Select(d => new SelectListItem
            {
                Value = d.DoktorID.ToString(),
                Text = d.DoktorAdi
            }).ToList();

            return View(model);
        }

        public IActionResult HastaSil(int id)
        {
            var hasta = _context.Hastalar.Find(id);
            if (hasta != null)
            {
                _context.Hastalar.Remove(hasta);
                _context.SaveChanges();
            }
            return RedirectToAction("HastaListesi");
        }
    }
}
