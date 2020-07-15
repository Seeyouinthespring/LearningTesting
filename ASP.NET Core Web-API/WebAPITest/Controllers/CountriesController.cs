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
        private readonly ICommonRepository<Country> _repo;
        private readonly WebAPIContext _context;

        public CountriesController(ICommonRepository<Country> repo, WebAPIContext context)
        {
            _repo = repo;
            _context = context;
        }

        // GET: api/Countries
        [HttpGet(Name = "GetCountries")]
        public IEnumerable<Country> GetCountries()
        {
            return _repo.Get();
        }

        // GET: api/Countries/5
        [HttpGet("{id}", Name = "GetCountryById")]
        public IActionResult GetCountry(int id)
        {
            Country country = _repo.FindById(id);

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

            _repo.Update(country);

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
            _repo.Create(country);
            return CreatedAtRoute("GetCountryById", new { country.id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var country = _repo.FindById(id);
            if (country == null)
            {
                return NotFound();
            }

            _repo.Remove(country);
            return CreatedAtRoute("GetCountryById", new { country.id }, country);
        }

        [HttpPost(Name = "InsertManyCountries")]
        [Route("addManyCountries")]
        public ActionResult<List<Country>> CreateCountries([FromBody] List<Country> list, int something) 
        {
            _repo.CreateAll(list);
            return CreatedAtAction("GetCountries", list);
        }

        [HttpGet("pop/{population}", Name ="getCountriesWithPopulation")]
        //[Route("pop/{population}")]
        public IEnumerable<Country> getCountriesWithNumberOfPeopleMoreThan(int population)
        {
            return _repo.GetByCondition(p=>p.population>population);
        }

        [HttpGet("wcity")]
        public IEnumerable<Country> getCountriesWithCities()
        {
            //return _context.Countries.Include(x => x.Cities).ToList();
            return _repo.GetWithInclude(z=>z.Cities).ToList();
        }
    }
}
