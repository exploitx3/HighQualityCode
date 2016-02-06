using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheatreSystem.Tests
{
    using System.Linq;
    using Exceptions;
    using Interfaces;
    using Models;

    [TestClass]
    public class PerformanceDatabaseTests
    {
        IPerformanceDatabase performanceDatabase;

        [TestInitialize]
        public void Inicialize_TestDatabase()
        {
            performanceDatabase = new PerformanceDatabase();
        }

        [TestMethod]
        public void TestAddTheatre_ShouldAddTheatre()
        {
            this.performanceDatabase.AddTheatre("TheatreTest");

            Assert.AreEqual("TheatreTest", performanceDatabase.ListTheatres().First());
        }

        [TestMethod]
        public void TestListTheatres_ShouldReturnIEnumerableOfTheatres()
        {
            this.performanceDatabase.AddTheatre("TheatreTest");
            this.performanceDatabase.AddTheatre("TheatreTest1");
            this.performanceDatabase.AddTheatre("TheatreTest2");

            Assert.AreEqual(3 , this.performanceDatabase.ListTheatres().Count());
            Assert.AreEqual("TheatreTest", this.performanceDatabase.ListTheatres().ElementAt(0));
            Assert.AreEqual("TheatreTest1", this.performanceDatabase.ListTheatres().ElementAt(1));
            Assert.AreEqual("TheatreTest2", this.performanceDatabase.ListTheatres().ElementAt(2));
        }

        [TestMethod]
        public void TestListPerformances_ShouldReturnIEnumerableOfPerformancesByTheatre()
        {
            DateTime testDateTime = DateTime.Today;
            TimeSpan testTimeSpan = new TimeSpan(0, 5, 6);
            decimal testPrice = 0.56M;

            this.performanceDatabase.AddTheatre("TheatreTest");
            this.performanceDatabase.AddPerformance("TheatreTest", "PerformanceTest", testDateTime, testTimeSpan, testPrice);
            this.performanceDatabase.AddPerformance("TheatreTest", "PerformanceTest", testDateTime.AddDays(1), testTimeSpan, testPrice);
            this.performanceDatabase.AddPerformance("TheatreTest", "PerformanceTest", testDateTime.AddDays(2), testTimeSpan, testPrice);

            Assert.AreEqual(3 , this.performanceDatabase.ListPerformances("TheatreTest").Count());
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void TestListPerformances_NonExistantTheatre_ThrowException()
        {
            this.performanceDatabase.ListPerformances("TheatreTest");
        }

        [TestMethod]
        public void TestAddPerformance_ShouldAddPerformanceToTheatre()
        {
            DateTime testDateTime = DateTime.Today;
            TimeSpan testTimeSpan = new TimeSpan(0, 5, 6);
            decimal testPrice = 0.56M;

            this.performanceDatabase.AddTheatre("TheatreTest");
            this.performanceDatabase.AddPerformance("TheatreTest", "PerformanceTest", testDateTime, testTimeSpan, testPrice);

            Assert.AreEqual(1 , this.performanceDatabase.ListPerformances("TheatreTest").Count());
            Assert.AreEqual("TheatreTest", this.performanceDatabase.ListPerformances("TheatreTest").ElementAt(0).TheatreName);
            Assert.AreEqual("PerformanceTest", this.performanceDatabase.ListPerformances("TheatreTest").ElementAt(0).PerformanceName);
            Assert.AreEqual(testDateTime, this.performanceDatabase.ListPerformances("TheatreTest").ElementAt(0).DateTime);
            Assert.AreEqual(testTimeSpan, this.performanceDatabase.ListPerformances("TheatreTest").ElementAt(0).Duration);
            Assert.AreEqual(testPrice, this.performanceDatabase.ListPerformances("TheatreTest").ElementAt(0).Price);
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void TestAddPerformance_AddToNonExistantTheatre_ShouldThrowException()
        {
            DateTime testDateTime = DateTime.Today;
            TimeSpan testTimeSpan = new TimeSpan(0, 5, 6);
            decimal testPrice = 0.56M;

            this.performanceDatabase.AddPerformance("NonExistantTheatre", "PerformanceTest", testDateTime, testTimeSpan, testPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException))]
        public void TestAddPerformance_AddToPerformanceWithOverlappingDuration_ShouldThrowException()
        {
            DateTime testDateTime = DateTime.Today;
            TimeSpan testTimeSpan = new TimeSpan(0, 5, 6);
            decimal testPrice = 0.56M;

            this.performanceDatabase.AddTheatre("TheatreTest");
            this.performanceDatabase.AddPerformance("TheatreTest", "PerformanceTest", testDateTime, testTimeSpan, testPrice);
            this.performanceDatabase.AddPerformance("TheatreTest", "PerformanceTest2", testDateTime, testTimeSpan, testPrice);
        }
    }
}
