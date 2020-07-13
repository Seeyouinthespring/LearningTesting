using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationsTest
{
    class Match
    {
        public int id { get; set; }
        public DateTime start { get; set; }
        public string locationCity { get; set; }
        public string arena { get; set; }

        public int homeTeamId { get; set; }
        public Team homeTeam { get; set; }

        public int guestTeamId { get; set; }
        public Team guestTeam { get; set; }

        public int homeScore { get; set; }
        public int guestScore { get; set; }

    }
}
