using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Repository;
using WebAPITest.Models;
using WebAPITest.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        //private readonly ICityRepository _cityRepository;
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        // GET: api/<CityController>
        [HttpGet]
        public IEnumerable<City> Get()
        {
            return _cityService.Get();
        }

        // GET api/<CityController>/5
        [HttpGet("{id}", Name = "GetCityById")]
        public IActionResult Get(int id)
        {
            var item = _cityService.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/<CityController>
        [HttpPost]
        public IActionResult Create([FromBody] City item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _cityService.Create(item);
            return CreatedAtRoute("GetCityById", new { item.id }, item);
        }

        // PATCH api/<CityController>/5
        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody] City item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            if (id != item.id)
            {
                return NotFound();
            }

            item.id = id;
            _cityService.Update(item);
            return new NoContentResult();
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public IActionResult UpdatePut(int id, [FromBody] City item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            if (id != item.id)
            {
                return NotFound();
            }
            _cityService.Update(item);
            return new NoContentResult();
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var city = _cityService.FindById(id);
            if (city == null)
            {
                return NotFound();
            }

            _cityService.Remove(city);
            return CreatedAtRoute("GetCountryById", new { city.id }, city);
        }

        [HttpGet("everything")]
        public IEnumerable<City> GetWithEverything()
        {
            return _cityService.GetEverything();
        }


        [HttpGet("everything/{id}")]
        public City GetEverythingById(int id) {
            return _cityService.GetEverythingById(id);
        }
    }
}
