using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMessage _message;

        public UserController(IUserService service,IMessage message)
        {
            _service = service;
            _message = message;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult GetAllCourses(Guid userId)
        {
            _service.GetAllCourses(userId);
            return Ok(_service.GetAllCourses(userId));
        }
 

        // POST api/<UserController>
        [HttpPost]
        public IActionResult SubscribeCourse([FromBody] Guid userId, Course course)
        {
            _service.AddCourse(userId,course);
            return CreatedAtAction("GetAllCourses", new { userId = userId });
        }

        

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(Guid userId,int courseId)
        {
            var course  = _service.GetAllCourses(userId).FirstOrDefault(x=>x.Id == courseId);
            if (course == null)
            {
                return NotFound();
            }
            _service.RemoveSubscribedCourse(userId, courseId);
            return Ok(true);
        }



        public IActionResult SendMessage(string message, int userId, Messagetype messageType)
        {
            switch (messageType)
            {
                case Messagetype.Sms:
                    _message.Sms(message, userId);
                    break;
                case Messagetype.Email:
                    _message.Email(message, userId);

                    break;
            }


            return Ok(true);
        }
    }
}
