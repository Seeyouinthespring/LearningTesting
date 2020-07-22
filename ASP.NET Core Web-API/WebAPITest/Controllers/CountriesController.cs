using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using WebAPITest.Interfaces;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountriesController(ICountryService serv)
        {
            countryService = serv;
        }

        // GET: api/Countries
        [HttpGet(Name = "GetCountries")]
        public IEnumerable<Country> GetCountries()
        {
            return countryService.GetCountries();
        }

        // GET: api/Countries/5
        [HttpGet("{id}", Name = "GetCountryById")]
        public IActionResult GetCountry(int id)
        {
            Country country = countryService.FindCountryById(id);

            if (country == null)
            {
                return NotFound();
            }
            return new ObjectResult(country);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult UpdateCountry(int id, [FromBody] Country country)
        {
            //добавить логику с getbyid
            if (id != country.id)
            {
                return BadRequest();
            }

            countryService.UpdateCountry(country);

            return CreatedAtRoute("GetCountryById", new { country.id }, country);
        }

        // POST: api/Countries
        [HttpPost]
        [Route("addOne")]
        public IActionResult CreateCountry([FromBody] Country country)
        {
            if (country == null)
            {
                return BadRequest();
            }
            countryService.CreateCountry(country);
            return CreatedAtRoute("GetCountryById", new { country.id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var country = countryService.FindCountryById(id);
            if (country == null)
            {
                return NotFound();
            }

            countryService.RemoveCountry(country);
            return CreatedAtRoute("GetCountryById", new { country.id }, country);
        }

        [HttpPost("addManyCountries", Name = "InsertManyCountries")]
        public ActionResult<List<Country>> CreateCountries([FromBody] List<Country> list, int something)
        {
            countryService.CreateListCountries(list);
            return CreatedAtAction("GetCountries", list);
        }

        [HttpGet("pop/{population}", Name = "getCountriesWithPopulation")]
        public IEnumerable<Country> getCountriesWithNumberOfPeopleMoreThan(int population)
        {
            return countryService.GetCountriesByCondition(p => p.population > population);
        }

        [HttpGet("everything")]
        public IEnumerable<Country> getCountriesWithCities()
        {
            return countryService.GetCountriesWithEverything();
        }

        [HttpGet("condition/{param}")]
        public IEnumerable<Country> getCountriesWithEverythinfByCondition(int param)
        {
            return countryService.GetCountriesWithEverythingByCondition(x=>x.population<param);
        }

        [HttpGet("everything/{id}")]
        public Country getCountriesWithCities(int id)
        {
            return countryService.FindCountryByIdWithEverything(id);
        }
    }
}
