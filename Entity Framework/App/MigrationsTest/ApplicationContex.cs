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
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // использование Fluent API
            modelBuilder.Entity<Match>().Property(m => m.start).IsRequired();
            modelBuilder.Entity<Match>().Property(m => m.locationCity).IsRequired();
            modelBuilder.Entity<Match>().Property(m => m.arena).IsRequired();
            modelBuilder.Entity<Match>().Property(m => m.homeScore).IsOptional ();
            modelBuilder.Entity<Match>().Property(m => m.guestScore).IsOptional();
            modelBuilder.Entity<Team>().HasMany(m => m.Matches).WithRequired(p => p.homeTeam).HasForeignKey(k=>k.homeTeamId).WillCascadeOnDelete();
            modelBuilder.Entity<Team>().HasMany(m => m.Matches).WithRequired(p => p.guestTeam).HasForeignKey(k => k.guestTeamId).WillCascadeOnDelete();
            base.OnModelCreating(modelBuilder);
        }
    }

}
