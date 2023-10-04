using System.ComponentModel.DataAnnotations;

namespace WuıLayer.Models.TrenSefer
{
    public class TrenSeferUpdateDTO
    {

        public int id { get; set; }

        [Display(Name = "Kalkış İstasyon")]
        public int TrenKalkisIstasyonId { get; set; }

        [Display(Name ="Varış İstasyon")]
        public int TrenVarisIstasyonId { get; set; }


        public DateTime KalısSaati { get; set; }
        public DateTime VarisSaati { get; set; }
    }
}
