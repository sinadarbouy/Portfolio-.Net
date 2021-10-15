using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }


        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST api/<CourseController>
        [HttpPost]
        public IActionResult Post([FromBody] Course value)
        {
            var result = _service.Add(value);
            return CreatedAtAction("Get", new { id = result.Id });
        }
 
        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = _service.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            _service.Remove(id);
            return Ok(true);
        }
    }
}
