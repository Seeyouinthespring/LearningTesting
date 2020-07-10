using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationsTest
{
    class Tournament
    {
        public int Id { get; set; }
        public string name { get; set; }
        public Int64 prizepool { get; set; }

        public ICollection<Team> Teams { get; set; }
        public Tournament() 
        {
            Teams = new List<Team>();
        }
    }
}
