//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPITest.Interfaces;
using WebAPITest.Models;

namespace WebAPITest.Repository
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        protected WebAPIContext _context;

        public CommonRepository(WebAPIContext context)
        {
            _context = context;
        }

        public void Create(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void CreateAll(List<T> entitiesToInsert)
        {
            _context.AddRange(entitiesToInsert);
            _context.SaveChanges();
        }
        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> GetByCondition(Func<T, bool> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate);
        }

        public void Remove(T item)
        {
            _context.Remove<T>(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Update<T>(item);
            _context.SaveChanges();
        }

        public void UpdateAll(List<T> entitiesToUpdate)
        {
            _context.UpdateRange(entitiesToUpdate);
            _context.SaveChanges();
        }
        public IQueryable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties) 
        {
            IQueryable<T> query = _context.Set<T>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            //return Include(includeProperties).ToList();
            //return Include(includeProperties).ToList();
        }
    }
}
