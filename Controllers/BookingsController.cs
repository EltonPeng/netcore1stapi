using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netcore1stapi.Interfaces;
using netcore1stapi.Models;

namespace netcore1stapi.Controllers
{
    [Route("api/[controller]")]
    public class BookingsController : Controller
    {
        private IBookingRepositoryService repository;

        public BookingsController(IBookingRepositoryService bookingRepositoryService)
        {
            repository = bookingRepositoryService;
        }

        // GET api/values
        [HttpGet]
        public OkObjectResult Get()
        {
            return Ok(repository.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public OkObjectResult Get(int id)
        {
            return Ok(repository.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Item value)
        {
            repository.Add(value);
            return Created("Get", value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
