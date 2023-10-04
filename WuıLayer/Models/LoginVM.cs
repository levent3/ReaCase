using System.ComponentModel.DataAnnotations;

namespace WuıLayer.Models
{
    public class LoginVM
    {



        [Required(AllowEmptyStrings = false, ErrorMessage = "Kulalnıcı Alani Zorunludur")]
        public string KullaniciAdi { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre  Zorunludur")]
        public string Sifre { get; set; }

       


    }
}
