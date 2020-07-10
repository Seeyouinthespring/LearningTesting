using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationsTest
{
    class Coach
    {
        [Key, ForeignKey("Team")]
        public int Id { get; set; }
        public string fullname { get; set; }
        public int experience { get; set; }
        public virtual Team Team { get; set; }
    }
}
