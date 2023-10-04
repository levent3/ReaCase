using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract
{
    public interface IRepositoryBase<T>  where T : BaseEntity,new()
    {
       IQueryable<T> FindAllInclude(Expression<Func<T, bool>> filter = null
            , params Expression<Func<T, object>>[] include);
        IList<T> FindAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        T Update(T entity);
        T GetById(int id);
       
    }
}
