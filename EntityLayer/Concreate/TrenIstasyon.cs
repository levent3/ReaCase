using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class TrenIstasyon:BaseEntity
    {

        public string IstasyonAdi { get; set; }
        public string IstasyonAdresi { get; set; }
        public string IstasyonKonumu { get; set; }
        public ICollection<TrenSefer> KalkısIstasyonlar { get; set; }
        public ICollection<TrenSefer> VarisIstasyonlar { get; set; }

    }
}
