using Core.Interfaces;
using Moq;
using System.Collections.Generic;
using UnitTests.MockData;
using Xunit;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;

namespace UnitTests.Api
{
    public class CourseControllerAPITest
    {
        MoqData _moqdata;
        public CourseControllerAPITest()
        {
            _moqdata = new MoqData();
        }

        [Fact]//Get Courses
        public void GetTest()
        {
            //Arrange
            var moq = new Mock<ICourseService>();
            moq.Setup(p => p.GetAll()).Returns(_moqdata.GetAllCourse());
            CourseController apiController = new CourseController(moq.Object);
            ////Act
            var result = apiController.Get();
            ////Assert
            Assert.IsType<OkObjectResult>(result);
            var list = result as OkObjectResult;
            Assert.IsType<List<Course>>(list.Value);
        }


        [Theory]
        [InlineData(1, -1)]
        public void GetByIdTest(int ValidId, int inValidId)
        {
            //Arrange
            var moq = new Mock<ICourseService>();
            moq.Setup(p => p.GetById(ValidId)).Returns(_moqdata.GetAllCourse().Find(p => p.Id == ValidId));
            CourseController apiController = new CourseController(moq.Object);

            //Act

            var result = apiController.Get(ValidId);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var product = result as OkObjectResult;
            Assert.IsType<Course>(product.Value);

            //--------------------------


            //Arrange
            moq.Setup(p => p.GetById(inValidId)).Returns(_moqdata.GetAllCourse().Find(p => p.Id == inValidId));

            //Act

            var invalidResult = apiController.Get(inValidId);

            //Assert
            Assert.IsType<NotFoundResult>(invalidResult);


        }


        [Fact]
        public void Post_Test()
        {
            //Areange
            var moq = new Mock<ICourseService>();

            CourseController controller = new CourseController(moq.Object);

            Course course = new Course()
            {
                Id = 4,
                Description = "cccc",
                Name = "course 23",
                Code = "cskd"
            };


            //Act

            var result = controller.Post(course);

            //Assert

            Assert.IsType<CreatedAtActionResult>(result);


        }



        [Theory]
        [InlineData(1, -1)]
        public void Delete_Test(int ValidId, int inValidId)
        {
            //Arrange
            var moq = new Mock<ICourseService>();

            moq.Setup(p => p.Remove(ValidId));
            moq.Setup(p => p.GetById(ValidId)).Returns(_moqdata.GetAllCourse().Find(p => p.Id == ValidId));

            CourseController apiController = new CourseController(moq.Object);

            //Act
            var result = apiController.Delete(ValidId);
            var invalidResult = apiController.Delete(inValidId);
            //Assert

            Assert.IsType<OkObjectResult>(result);

            Assert.IsType<NotFoundResult>(invalidResult);
        }
    }
}
