using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPITest.Models;

namespace WebAPITest.Interfaces
{
    public interface ICountryService
    {
        public void CreateCountry(Country item);
        public void CreateListCountries(List<Country> entitiesToInsert);
        public Country FindCountryById(int id);
        public IEnumerable<Country> GetCountries();
        public IEnumerable<Country> GetCountriesByCondition(Func<Country, bool> predicate);
        public void RemoveCountry(Country item);
        public void UpdateCountry(Country item);
        public void UpdateListCountries(List<Country> entitiesToUpdate);

        public Country FindCountryByIdWithEverything(int id);

        public IEnumerable<Country> GetCountriesWithEverything();

        public IEnumerable<Country> GetCountriesWithEverythingByCondition(Expression<Func<Country, bool>> expression);
    }
}
