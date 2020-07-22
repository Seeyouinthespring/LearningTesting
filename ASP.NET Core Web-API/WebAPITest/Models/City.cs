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
        /// <summary>
        /// The official name of the city
        /// </summary>
        /// <example>"Moscow"</example>
        [Required]
        public string name { get; set; }
        /// <summary>
        /// Total area of the city (km^2)
        /// </summary>
        /// <example>1245</example>
        [Required]
        public float area { get; set; }
        /// <summary>
        /// The number of people lived in the city
        /// </summary>
        /// <example>12321898</example>
        [Required]
        public int population { get; set; }
        /// <summary>
        /// The official date of the foundation of the city
        /// </summary>
        /// <example>1812-04-03</example>
        public DateTime foundation { get; set; }
        [ForeignKey("Country")]
        public int? countryId { get; set; }
        public Country country { get; set; }

        public List<Sightseen> Sightseens { get; set; }
    }
}
