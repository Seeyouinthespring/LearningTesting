using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Interfaces;
using WebAPITest.Models;
using WebAPITest.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SightseensController : ControllerBase
    {
        protected readonly ISightseenService _service;

        public SightseensController(ISightseenService repo)
        {
            _service = repo;
        }

        // GET: api/<SightseensController>
        [HttpGet]
        public IEnumerable<Sightseen> Get()
        {
            return _service.GetSights();
        }

        // GET api/<SightseensController>/5
        [HttpGet("{id}", Name = "GetSightById")]
        public IActionResult Get(int id)
        {
            var item = _service.FindSightById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/<SightseensController>
        [HttpPost]
        public IActionResult Post([FromBody] Sightseen item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _service.CreateSight(item);
            return CreatedAtRoute("GetSightById", new { item.id }, item);
        }

        // PUT api/<SightseensController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Sightseen item)
        {
            if (id != item.id)
            {
                return BadRequest();
            }

            _service.UpdateSight(item);

            return CreatedAtRoute("GetCountryById", new { item.id }, item);
        }

        // DELETE api/<SightseensController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _service.FindSightById(id);
            if (item == null)
            {
                return NotFound();
            }
            _service.RemoveSight(item);
            return CreatedAtRoute("GetCountryById", new { item.id }, item);
        }

        [HttpGet("everything")]
        public IEnumerable<Sightseen> GetWithEverything()
        {
            return _service.GetSightsWithEverything();
        }

        // GET api/<SightseensController>/5
        [HttpGet("everything/{id}", Name = "GetSightByIdWithEverything")]
        public IActionResult GetWithEveryThingById(int id)
        {
            var item = _service.FindSightByIdWithEverything(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("condition/{param}")]
        public IEnumerable<Sightseen> GetWithEverythingByCondition(int param)
        {
            return _service.GetSightsWithEverythingByCondition(x=>x.city.country.population>param);
        }
    }
}
