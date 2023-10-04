namespace WuıLayer.Models.Kullanici
{
    public class KullaniciUpdateDTO
    {




        public int id { get; set; }
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = false, ErrorMessage = "Kullanıcı Adı Zorunlu Alandir")]
        public string KullaniciAdi { get; set; }
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = false, ErrorMessage = "Sifre  Zorunludur Zorunlu Alandir")]
        public string Sifre { get; set; }
        
    }
}
