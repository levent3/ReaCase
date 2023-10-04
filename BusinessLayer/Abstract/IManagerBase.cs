using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IManagerBase<T> where T : BaseEntity, new()
    {
        IList<T> FindAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter=null);

        List<T> GetList();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);

      

    }
}
