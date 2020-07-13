using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Models;

namespace WebAPITest.Repository
{
    public interface ICityRepository
    {
        void Create(City item);
        City FindById(int id);
        IEnumerable<City> Get();
        IEnumerable<City> Get(Func<City, bool> predicate);
        City Remove(City item);
        void Update(City item);
    }
}
