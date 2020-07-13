using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Models
{
    public class City
    {
        [Key]
        public int id { set; get; }
        [Required]
        public string name { get; set; }
        [Required]
        public float area { get; set; }
        [Required]
        public int population { get; set; }
        public DateTime foundation { get; set; }
    }
}
