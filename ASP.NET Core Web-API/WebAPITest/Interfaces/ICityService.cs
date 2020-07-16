using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Interfaces;
using WebAPITest.Models;

namespace WebAPITest.Services
{
    public interface ICityService : ICommonRepository<City>
    {
        public IQueryable<City> GetEverything();
        public City GetEverythingById(int id);
    }

}
