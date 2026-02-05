namespace HastaneDoktorListesi.ViewModels
{
    public class DoktorEkle_VM
    {
        public int DoktorID { get; set; }
        public string DoktorAdi { get; set; }
        public string DoktorÜnvan { get; set; }
        public IFormFile DoktorProfilResmi { get; set; }
    }
}
