namespace HastaneBilgiListeleri.Models
{
    public class Hastalik
    {
        public int HastalikID {  get; set; }
        public string HastalikAd {  get; set; }

        public int IlacID { get; set; }
        public virtual Ilac Ilac { get; set; }
    }
}
