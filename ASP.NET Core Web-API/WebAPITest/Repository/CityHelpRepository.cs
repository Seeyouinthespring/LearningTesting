using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Models;

namespace WebAPITest.Repository
{
    public class CityHelpRepository
    {
        protected WebAPIContext _context;

        public CityHelpRepository(WebAPIContext context)
        {
            _context = context;
        }

        public int CreateUnique(City city)
        {
            SqlParameter param1 = new SqlParameter("@code", city.code);
            SqlParameter param2 = new SqlParameter("@name", city.name);
            SqlParameter param3 = new SqlParameter("@country", city.countryId );
            object[] arr = new[] { param1, param2, param3 };
            return _context.Database.ExecuteSqlCommand("addCityWithCodeAndNameUniqueCheck @code, @name, @country", arr);
            //_context.SaveChanges();
        }
    }
}
