using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Data.Entity;

namespace WebAPITest.Models
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
    }
}
