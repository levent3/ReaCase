using DataLayer.Abstract;
using DataLayer.Contexts;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataLayer.Concreate
{
    public class RepositroyBase<T> : IRepositoryBase<T> where T : BaseEntity, new()
    {
        protected SqlDbContext _context { get; }
        DbSet<T> _entities;
        public RepositroyBase(SqlDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public T Add(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
            return entity;
        }


        public T Get(Expression<Func<T, bool>> filter)
        {
            return _entities.Where(filter).AsNoTracking().SingleOrDefault();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _entities.AsNoTracking().ToList() : _entities.Where(filter).AsNoTracking().ToList();
        }

        public T Update(T entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public IList<T> FindAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
                return  _entities.Where(filter).ToList();
            else
                return _entities.ToList();
        }

        public IQueryable<T> FindAllInclude(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] include)
        {
            if (filter != null)
            {
                _entities.Where(filter);
            }
            var result = include.Aggregate(_entities.AsQueryable(),
                                    (current, includeprop) => current.Include(includeprop));
            return result;
        }
    }
}
