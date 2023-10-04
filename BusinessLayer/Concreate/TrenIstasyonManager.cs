using BusinessLayer.Abstract;
using DataLayer.Abstract;
using DataLayer.Contexts;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class TrenIstasyonManager : ManagerBase<TrenIstasyon>, ITrenIstasyonManager
    {
        public TrenIstasyonManager(SqlDbContext context) : base(context)
        {

        }
    }
}
