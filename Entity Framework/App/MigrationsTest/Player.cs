using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationsTest
{
    class Player
    {
        public int Id { get; set; }
        public string fullname { get; set; }
        [Range(1,99)]
        public int number { get; set; }
        public DateTime birthdate { get; set; }

        public int? TeamId { get; set; }
        public Team Team { get; set; }

    }
}
