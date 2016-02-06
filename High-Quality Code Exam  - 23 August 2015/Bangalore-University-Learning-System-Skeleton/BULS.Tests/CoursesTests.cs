using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BULS.Tests
{
    using System.Linq;
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Enum;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using Moq;

    [TestClass]
    public class UnitTest1
    {
        private IBangaloreUniversityDatebase mockedData;
        private Course course;

        [TestInitialize]
        public void Initialize_Mocks()
        {
            var dataMock = new Mock<IBangaloreUniversityDatebase>();
            var courseRepoMock = new Mock<IRepository<Course>>();
            this.course = new Course("C# babies");
            courseRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(this.course);

            dataMock.Setup(r => r.Courses)
                .Returns(courseRepoMock.Object);

            this.mockedData = dataMock.Object;
        }

        [TestMethod]
        public void AddLecture_()
        {
            //Arrange
            var controller = new CoursesController(
                this.mockedData,
                new User("pefsho", "1233334", Role.Lecturer));

            string lectureName = DateTime.Now.ToString();
            
            //Act
            var view = controller.AddLecture(5, lectureName);

            //Assert
            Assert.AreEqual(this.course.Lectures.First().Name, lectureName);
            Assert.IsNotNull(view);
        }
    }
}
