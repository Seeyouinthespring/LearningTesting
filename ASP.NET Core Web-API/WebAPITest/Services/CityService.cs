using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Threading.Tasks;
using WebAPITest.Interfaces;
using WebAPITest.Models;
using WebAPITest.Repository;

namespace WebAPITest.Services
{
    public class CityService : ICityService
    {

        private readonly CommonRepositoryInclude<City> _includeRepo;
        private readonly CommonRepository<City> _repo;
        private readonly CityHelpRepository _cityRepo;

        public CityService(WebAPIContext context)
        {
            _includeRepo = new CommonRepositoryInclude<City>(context, GetEntities);
            _repo = new CommonRepository<City>(context);
            _cityRepo = new CityHelpRepository(context);
        }

        private IQueryable<City> GetEntities(IQueryable<City> query)
        {
            return query.Include(x => x.country);
        }
        public void Create(City item)
        {
            _repo.Create(item);
        }

        public void CreateAll(List<City> entitiesToInsert)
        {
            _repo.CreateAll(entitiesToInsert);
        }

        public City FindById(int id)
        {
            return _repo.FindById(id);
        }

        public IEnumerable<City> Get()
        {
            return _repo.Get();
        }

        public IEnumerable<City> GetByCondition(Func<City, bool> predicate)
        {
            return _repo.GetByCondition(predicate);
        }

        public void Remove(City item)
        {
            _repo.Remove(item);
        }

        public void Update(City item)
        {
            _repo.Update(item);
        }

        public void UpdateAll(List<City> entitiesToUpdate)
        {
            _repo.UpdateAll(entitiesToUpdate);
        }


        public IQueryable<City> GetEverything()
        {
            return _includeRepo.GetAll();
        }

        public City GetEverythingById(int id)
        {
            return _includeRepo.GetById(x=>x.id==id);
        }

        public int CreateUnique(City item)
        {
           return _cityRepo.CreateUnique(item);
        }
    }
}
