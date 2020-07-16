using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPITest.Interfaces;
using WebAPITest.Models;
using WebAPITest.Repository;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace WebAPITest.Services
{
    public class CountryService : ICountryService
    {
        private readonly CommonRepositoryInclude<Country> repoInclude;
        private readonly CommonRepository<Country> repo;

        public CountryService(WebAPIContext context)
        {
            this.repoInclude = new CommonRepositoryInclude<Country>(context,getEntities);
            this.repo = new CommonRepository<Country>(context);
        }

        private IQueryable<Country> getEntities(IQueryable<Country> arg)
        {
            return arg.Include(x => x.Cities).ThenInclude(y => y.Sightseens).Include(z => z.Cities);
        }

        public void CreateCountry(Country item)
        {
            repo.Create(item);
        }

        public void CreateListCountries(List<Country> entitiesToInsert)
        {
            repo.CreateAll(entitiesToInsert);
        }

        public Country FindCountryById(int id)
        {
            return repo.FindById(id);
        }

        public Country FindCountryByIdWithEverything(int id)
        {
            return repoInclude.GetById(x=>x.id==id);
        }

        public IEnumerable<Country> GetCountries()
        {
            return repo.Get();
        }

        public IEnumerable<Country> GetCountriesByCondition(Func<Country, bool> predicate)
        {
            return repo.GetByCondition(predicate);
        }

        public IEnumerable<Country> GetCountriesWithEverything()
        {
            return repoInclude.GetAll();
        }

        public IEnumerable<Country> GetCountriesWithEverythingByCondition(Expression<Func<Country, bool>> expression)
        {
            return repoInclude.GetByCondition(expression);
        }

        public void RemoveCountry(Country item)
        {
            repo.Remove(item);
        }

        public void UpdateCountry(Country item)
        {
            repo.Update(item);
        }

        public void UpdateListCountries(List<Country> entitiesToUpdate)
        {
            repo.UpdateAll(entitiesToUpdate);
        }
    }
}
