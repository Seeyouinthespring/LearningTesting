using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationsTest
{
    class ApplicationContex: DbContext
    {

        public ApplicationContex() 
            : base("DBConnection") { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
    }
}
