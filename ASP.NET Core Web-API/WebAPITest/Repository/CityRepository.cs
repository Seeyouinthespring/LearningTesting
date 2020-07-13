using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPITest.Models;

namespace WebAPITest.Repository
{
    public class CityRepository: ICityRepository
    {
        DbContext _context;
        DbSet<City> _dbSet;
        public CityRepository(DbContext context)

        {
            _context = context;
            _dbSet = context.Set<City>();
        }
        public void Create(City item)

        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public City FindById(int id)
        {
            return _dbSet.Find(id);
        }
        public IEnumerable<City> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        public IEnumerable<City> Get(Func<City, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public City Remove(City item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
            return item;
        }
        public void Update(City item)

        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public IEnumerable<City> GetWithInclude(params Expression<Func<City, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }
        public IEnumerable<City> GetWithInclude(Func<City, bool> predicate,
            params Expression<Func<City, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }
        private IQueryable<City> Include(params Expression<Func<City, object>>[] includeProperties)
        {
            IQueryable<City> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
