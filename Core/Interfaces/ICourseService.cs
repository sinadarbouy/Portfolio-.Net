using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAll();
        Course Add(Course product);
        Course GetById(int id);
        void Remove(int id);
    }
}
