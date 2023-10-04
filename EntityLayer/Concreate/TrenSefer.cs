using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class TrenSefer:BaseEntity
    {

        // Diğer özellikler

        public int TrenKalkisIstasyonId { get; set; }
        public TrenIstasyon TrenKalkisIstasyon { get; set; }

        public int TrenVarisIstasyonId { get; set; }
        public TrenIstasyon TrenVarisIstasyon { get; set; }
   

        public DateTime KalısSaati { get; set; }
        public DateTime VarisSaati { get; set; }
       
    }
}
