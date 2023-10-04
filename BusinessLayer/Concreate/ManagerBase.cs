using BusinessLayer.Abstract;
using DataLayer.Abstract;
using DataLayer.Concreate;
using DataLayer.Contexts;
using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class ManagerBase<T> : IManagerBase<T> where T : BaseEntity, new()
    {
        private readonly DataLayer.Abstract.IRepositoryBase<T> _repositoryBase;
        protected SqlDbContext _context { get; }

        public ManagerBase(SqlDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositroyBase<T>(context);
        }

        public void Add(T entity)
        {
           _repositoryBase.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            var data=_repositoryBase.Get(filter);   
            return data;
        }

        public T GetById(int id)
        {
            var data = _repositoryBase.Get(x => x.Id == id);
            
            return data;
        }

        public List<T> GetList()
        {
            var data = _repositoryBase.GetList();          
            return data;
        }

        public void Update(T entity)
        {
            _repositoryBase.Update(entity);
        }

        public IList<T> FindAll(Expression<Func<T, bool>> filter = null)
        {
           var result= _repositoryBase.FindAll(filter);   

            return result;
        }
    }
}
