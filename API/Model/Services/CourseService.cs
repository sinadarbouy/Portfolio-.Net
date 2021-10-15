using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace API.Model.Services
{
    class CourseService : ICourseService
    {
        private readonly DataBaseContext _context;
        public CourseService(DataBaseContext context)
        {
            _context = context;
        }
        public Course Add(Course course)
        {
            _context.courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.courses.Find(id);
        }

        public void Remove(int id)
        {
            var product = _context.courses.Find(id);
            _context.courses.Remove(product);
        }
    }
}
