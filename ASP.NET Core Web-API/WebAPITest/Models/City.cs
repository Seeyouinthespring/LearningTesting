using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Country")]
        public int? countryId { get; set; }
        public Country country { get; set; }

        public List<Sightseen> Sightseens { get; set; }
    }
}
