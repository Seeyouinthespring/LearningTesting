using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationsTest
{
    class Team
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string city { get; set; }
        public ICollection<Player> Players {get;set;}
        public virtual Coach coach { get; set; }

        public ICollection<Tournament> Tournaments { get; set; }
        public ICollection<Match> Matches { get; set; } 

        public Team() {
            Tournaments = new List<Tournament>();
            Matches = new List<Match>();
        }
    }
}
