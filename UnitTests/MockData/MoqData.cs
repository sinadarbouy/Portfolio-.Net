using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockData
{
    public class MoqData
    {
        public List<Course> GetAllCourse()
        {
            List<Course> courses = new List<Course>()
            {
                 new Course { Id = 1 , Description ="Course 1",Name="SE",Code="Dat1"},
                 new Course { Id = 2 , Description ="Course 2" , Name="SE2",Code="Dat2"},
            };
            return courses;
        }

        public List<User> GetAllUser() {
            List<User> users = new List<User>() {
                new User{Id=Guid.Empty,Email="user@user.com",UserName="User1",courses=new List<Course>{
                  new Course { Id = 1 , Description ="Course 1",Name="SE",Code="Dat1"},
                 new Course { Id = 2 , Description ="Course 2" , Name="SE2",Code="Dat2"},
                } }


            };
            return users;
            
        
        }
    }
}
