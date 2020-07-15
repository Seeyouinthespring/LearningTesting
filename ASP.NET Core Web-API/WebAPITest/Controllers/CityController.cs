using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Repository;
using WebAPITest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository r)
        {
            _cityRepository = r;
        }
        // GET: api/<CityController>
        [HttpGet]
        public IEnumerable<City> Get()
        {
            return _cityRepository.Get();
        }

        // GET api/<CityController>/5
        [HttpGet("{id}", Name = "GetCityById")]
        public IActionResult Get(int id)
        {
            var item = _cityRepository.FindById(id);
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
            _cityRepository.Create(item);
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

            var city = _cityRepository.FindById(id);
            if (city == null)
            {
                return NotFound();
            }

            item.id = id;
            _cityRepository.Update(item);
            return new NoContentResult();
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public IActionResult UpdatePut(int id, [FromBody] City item)
        {
            if (item == null || item.id != id)
            {
                return BadRequest();
            }

            var city = _cityRepository.FindById(id);
            if (city == null)
            {
                return NotFound();
            }
            _cityRepository.Update(item);
            return new NoContentResult();
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public City Delete(int id)
        {
            City todo = _cityRepository.FindById(id);
            if (todo == null)
            {
                return null;
            }

            return _cityRepository.Remove(todo);
            //return new NoContentResult();
        }
    }
}
