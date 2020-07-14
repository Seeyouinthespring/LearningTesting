using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPITest.Models;

namespace WebAPITest.Repository
{
    public class CityRepository: ICityRepository
    {
        WebAPIContext _context;
        DbSet<City> _dbSet;
        public CityRepository(WebAPIContext context)

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
            var cities = _dbSet.AsNoTracking<City>().Where(ent => ent.id == id);
            City a= new City();
            foreach (City c in cities)
                a = c;

            //var c = _dbSet.AsNoTracking().Where(ent => ent.id == id);
            //City city = (City)c;
            //var ct = _context.Find<City>(id);
            //return _dbSet.Find(id);
            return a;
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
            //_context.Set<City>().Update(item);
            //_context.Entry(item).CurrentValues.SetValues(item); //.State = EntityState.Modified;
            _context.Entry<City>(item).State = EntityState.Modified;
            //_context.Cities.Attach(item);
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
