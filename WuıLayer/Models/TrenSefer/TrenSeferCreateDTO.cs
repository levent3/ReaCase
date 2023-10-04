namespace WuıLayer.Models.TrenSefer
{
    public class TrenSeferCreateDTO
    {
        public int id { get; set; }

        public int TrenKalkisIstasyonId { get; set; }
    

        public int TrenVarisIstasyonId { get; set; }
       


        public DateTime KalısSaati { get; set; }
        public DateTime VarisSaati { get; set; }
    }
}
