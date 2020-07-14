using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Models
{
    public class Sightseen
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
}
