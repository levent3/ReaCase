using DataLayer.Abstract;
using DataLayer.Contexts;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Concreate
{
    public class KullaniciDAL : RepositroyBase<Kullanici>, IKullaniciDal
    {
        public KullaniciDAL(SqlDbContext context) : base(context)
        {
        }
    }
}
