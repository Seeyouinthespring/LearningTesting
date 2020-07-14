using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebAPITest.Models
{
    public class WebAPIContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public WebAPIContext(DbContextOptions<WebAPIContext> opt): base(opt)
        {
            Database.EnsureCreated();
        }

        public Microsoft.EntityFrameworkCore.DbSet<City> Cities { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Country> Countries { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Sightseen> Sightseens { get; set; }
    }
}
