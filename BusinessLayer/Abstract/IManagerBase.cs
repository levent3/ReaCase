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

        IQueryable<T> FindAllInclude(Expression<Func<T, bool>>? filter = null
            , params Expression<Func<T, object>>[]? include);
        IList<T> FindAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter=null);

        List<T> GetList();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        T Delete(T entity);



    }
}
