using Microsoft.AspNetCore.Mvc.Rendering;

namespace HastaneBilgiListeleri.ViewModels
{
    public class HastalikEkle_VM
    {
        public int HastalikID {  get; set; }
        public string HastalikAd {  get; set; }
        public int IlacID { get; set; }
        public List<SelectListItem> IlacListesi { get; set; } = new List<SelectListItem>();

    }
}
