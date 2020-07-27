using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Interfaces;
using WebAPITest.Models;

namespace WebAPITest.Services
{
    public interface ICityService
    {
        public void Create(City item);
        public void CreateAll(List<City> entitiesToInsert);
        public City FindById(int id);
        public IEnumerable<City> Get();
        public IEnumerable<City> GetByCondition(Func<City, bool> predicate);
        public void Remove(City item);
        public void Update(City item);
        public void UpdateAll(List<City> entitiesToUpdate);
        public IQueryable<City> GetEverything();
        public City GetEverythingById(int id);


        public int CreateUnique(City item);
    }

}
