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
    public class TrenSeferManager : ManagerBase<TrenSefer>, ITrenSeferManager
    {
        public TrenSeferManager(SqlDbContext context) : base(context)
        {

        }
    }
}
