using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Models
{
    public class Country
    {
        [Key]
        public int id { get; set; }
        public string name { set; get; }
        public Int64 population { get; set; }
        public string officialLanguage { get; set; }
        public string flagImgUrl { get; set; }

        public List<City> Cities { get; set; }

    }
}
