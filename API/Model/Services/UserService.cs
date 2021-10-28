using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace API.Model.Services
{
    public class UserService : IUserService
    {
        private readonly DataBaseContext _context;
        public UserService(DataBaseContext context)
        {
            _context = context;
        }
        public Course AddCourse(Guid UserId,Course course)
        {
            var user= _context.users.Find(UserId);
            user.courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public IEnumerable<Course> GetAllCourses(Guid UserId)
        {
            var user = _context.users.Find(UserId);
            return user.courses;
        }

        public void RemoveSubscribedCourse(Guid UserId, Course course)
        {
            var user = _context.users.Find(UserId);
            user.courses.Remove(course);
           
        }

        public void RemoveSubscribedCourse(Guid UserId, int CourseId)
        {
            throw new NotImplementedException();
        }
    }
   
}
