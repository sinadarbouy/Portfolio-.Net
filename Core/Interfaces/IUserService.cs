using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserService 
    {
        IEnumerable<Course> GetAllCourses(Guid UserId);
        Course AddCourse(Guid UserId, Course Course);
        void RemoveSubscribedCourse(Guid UserId, int CourseId);
    }
}
