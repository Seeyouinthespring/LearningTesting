using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Interfaces;
using WebAPITest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SightseensController : ControllerBase
    {
        protected readonly ICommonRepository<Sightseen> _repo;

        public SightseensController(ICommonRepository<Sightseen> repo)
        {
            _repo = repo;
        }


        // GET: api/<SightseensController>
        [HttpGet]
        public IEnumerable<Sightseen> Get()
        {
            return _repo.Get();
        }

        // GET api/<SightseensController>/5
        [HttpGet("{id}", Name ="GetSightById")]
        public IActionResult Get(int id)
        {
            var item = _repo.FindById(id);
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
            _repo.Create(item);
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

            _repo.Update(item);

            return CreatedAtRoute("GetCountryById", new { item.id }, item);
        }

        // DELETE api/<SightseensController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _repo.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            _repo.Remove(item);
            return CreatedAtRoute("GetCountryById", new { item.id }, item);
        }
    }
}
