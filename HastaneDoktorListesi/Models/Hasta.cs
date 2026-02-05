using HastaneBilgiListeleri.Models;

namespace HastaneDoktorListesi.Models
{
    public class Hasta
    {
        public int HastaID { get; set; }
        public string HastaAd { get; set; }
        public string HastaProfilResmi { get; set; }
        public int DoktorID { get; set; }
        public virtual Doktor Doktor { get; set; }
        public int HastalıkID { get; set; }
        public virtual Hastalik Hastalık { get; set; }

    }
}
