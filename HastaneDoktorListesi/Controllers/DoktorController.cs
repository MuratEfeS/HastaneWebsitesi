using Microsoft.AspNetCore.Mvc;
using HastaneDoktorListesi.Data;
using HastaneDoktorListesi.ViewModels;
using HastaneDoktorListesi.Models;

namespace HastaneDoktorListeleri.Controllers
{
    public class DoktorController : Controller
    {
        HastaneDBContext _context = new HastaneDBContext();
        public IActionResult Index()
        {
            _context.Database.EnsureCreated();
            return View();
        }

        public IActionResult DoktorEkle()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult DoktorEkle(DoktorEkle_VM doktor)
        {
            FileStream fs = new FileStream("wwwroot/DoktorProfilePic/" + doktor.DoktorProfilResmi.FileName, FileMode.Create);
            doktor.DoktorProfilResmi.CopyTo(fs);

            Doktor yeniDoktor = new Doktor()
            {
                DoktorAdi = doktor.DoktorAdi,
                DoktorÜnvan = doktor.DoktorÜnvan,
                DoktorProfilResmi = doktor.DoktorProfilResmi.FileName

            };


            _context.Doktorlar.Add(yeniDoktor);
            _context.SaveChanges();
            
            return RedirectToAction("DoktorlarListesi");
        }
       
        public IActionResult DoktorlarListesi()
        {
            var doktorlar = _context.Doktorlar.ToList();
            return View(doktorlar);
        }

    
        [HttpGet]
        public IActionResult DoktorDuzenle(int id)
        {
            var d = _context.Doktorlar.Find(id);
            if (d == null) return NotFound();

            var vm = new DoktorEkle_VM
            {
                DoktorID = d.DoktorID,
                DoktorAdi = d.DoktorAdi,
                DoktorÜnvan = d.DoktorÜnvan.ToString()
            };
            return View(vm);
        }

       
        [HttpPost]
        public IActionResult DoktorDuzenle(DoktorEkle_VM model)
        {
            var d = _context.Doktorlar.Find(model.DoktorID);
            if (d == null) return NotFound();

            d.DoktorAdi = model.DoktorAdi;
            d.DoktorÜnvan = model.DoktorÜnvan;

            if (model.DoktorProfilResmi != null)
            {
                string dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(model.DoktorProfilResmi.FileName);
                string yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DoktorProfilePic", dosyaAdi);

                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    model.DoktorProfilResmi.CopyTo(stream);
                }
                d.DoktorProfilResmi = dosyaAdi;
            }
            _context.SaveChanges();
            return RedirectToAction("DoktorlarListesi");
        }
        public IActionResult DoktorSil(int id)
        {
            var doktor = _context.Doktorlar.Find(id);
            if (doktor != null)
            {
                _context.Doktorlar.Remove(doktor);
                _context.SaveChanges();
            }
            return RedirectToAction("DoktorlarListesi");
        }
    }
}
