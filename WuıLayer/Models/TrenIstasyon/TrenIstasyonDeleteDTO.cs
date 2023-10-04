namespace WuıLayer.Models.TrenIstasyon
{
    public class TrenIstasyonDeleteDTO
    {

        public int id { get; set; }
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = false, ErrorMessage = "İstasyon Adı Zorunlu Alandir")]
        public string IstasyonAdi { get; set; }
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = false, ErrorMessage = "Istasyon Adresi Zorunludur Zorunlu Alandir")]
        public string IstasyonAdresi { get; set; }
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = false, ErrorMessage = "Istasyon Konumu Zorunlu Alandir")]
        public string IstasyonKonumu { get; set; }
    }
}
