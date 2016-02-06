namespace VehicleParkSystem.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models.Vehicles;

    [TestClass]
    public class GetStatusTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void Test_GetStatus_EmptyPark_SinglePlaceOnly_ShouldBeCorrect()
        {
            var park = new VehiclePark(1, 1);

            string message = park.GetStatus();
            Assert.AreEqual("Sector 1: 0 / 1 (0% full)", message);
        }

        [TestMethod]
        public void Test_GetStatus_EmptyPark_Big_ShouldBeCorrect()
        {
            var park = new VehiclePark(3, 3);

            string message = park.GetStatus();
            Assert.AreEqual(
                "Sector 1: 0 / 3 (0% full)\r\n" +
                "Sector 2: 0 / 3 (0% full)\r\n" +
                "Sector 3: 0 / 3 (0% full)",
                message);
        }

        [TestMethod]
        public void Test_GetStatus_FullPark_SinglePlaceOnly_ShouldBeCorrect()
        {
            var park = new VehiclePark(1, 1);
            var car = new Car("CA1011AH", "John Smith", 1);
            park.InsertCar(car, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            string message = park.GetStatus();
            Assert.AreEqual("Sector 1: 1 / 1 (100% full)", message);
        }

        [TestMethod]
        public void Test_GetStatus_PartiallyFullPark_Big_ShouldBeCorrect()
        {
            var park = new VehiclePark(3, 3);
            var car = new Car("CA1011AH", "John Smith", 1);
            park.InsertCar(car, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            car = new Car("CA1012AH", "John Smith", 1);
            park.InsertCar(car, 2, 2, new DateTime(2015, 5, 10, 10, 30, 0));
            car = new Car("CA1013AH", "John Smith", 1);
            park.InsertCar(car, 2, 1, new DateTime(2015, 5, 10, 10, 30, 0));

            string message = park.GetStatus();
            Assert.AreEqual(
                "Sector 1: 1 / 3 (33% full)\r\n" +
                "Sector 2: 2 / 3 (67% full)\r\n" +
                "Sector 3: 0 / 3 (0% full)",
                message);
        }
    }
}
