namespace WuıLayer.Models.TrenIstasyon
{
    public class TrenIstasyonListDTO
    {
        public int TrenKalkisIstasyonId { get; set; }
        public string TrenKalkisIstasyonAdi { get; set; }
        public int TrenVarisIstasyonId { get; set; }
        public string TrenVarisIstasyonAdi { get; set; }

        public DateTime KalısSaati { get; set; }
        public DateTime VarisSaati { get; set; }
        public int Id { get; set; }
    }
}
