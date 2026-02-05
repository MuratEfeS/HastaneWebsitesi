using HastaneBilgiListeleri.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HastaneDoktorListesi.ViewModels
{
    public class HastaEkle_VM
    {
        public int HastaID { get; set; }
        public string HastaAd { get; set; }
        public IFormFile HastaProfilResmi { get; set; }
        public int DoktorID { get; set; }
        public int HastalıkID { get; set; }

        public List<SelectListItem> DoktorListesi { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> HastalikListesi { get; set; } = new List<SelectListItem>();
    }
}
