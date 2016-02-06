namespace VehicleParkSystem.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models.Vehicles;

    [TestClass]
    public class InsertTruckTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void Test_InsertTruck_CorrectParameters_ShouldInsertTheTruck()
        {
            var park = new VehiclePark(2, 2);
            var truck = new Truck("CA1011AH", "John Smith", 1);
            string message = park.InsertTruck(truck, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("Truck parked successfully at place (1,1)", message);
        }

        [TestMethod]
        public void Test_InsertTruck_FillPark_ShouldInsertAllTrucks()
        {
            var park = new VehiclePark(2, 1);
            var truck = new Truck("CA1011AH", "John Smith", 1);
            string message = park.InsertTruck(truck, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("Truck parked successfully at place (1,1)", message);

            var otherTruck = new Truck("CA1022AH", "Jane Smith", 1);
            message = park.InsertTruck(otherTruck, 2, 1, new DateTime(2015, 5, 10, 12, 30, 0));
            Assert.AreEqual("Truck parked successfully at place (2,1)", message);
        }

        [TestMethod]
        public void Test_InsertTruck_IncorrectSector_ShouldReturnErrorMessage()
        {
            var park = new VehiclePark(2, 2);
            var truck = new Truck("CA1011AH", "John Smith", 1);
            string message = park.InsertTruck(truck, 10, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("There is no sector 10 in the park", message);
        }

        [TestMethod]
        public void Test_InsertTruck_IncorrectPlace_ShouldReturnErrorMessage()
        {
            var park = new VehiclePark(2, 2);
            var truck = new Truck("CA1011AH", "John Smith", 1);
            string message = park.InsertTruck(truck, 1, 10, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("There is no place 10 in sector 1", message);
        }

        [TestMethod]
        public void Test_InsertTruck_OccupiedPlace_ShouldReturnErrorMessage()
        {
            var park = new VehiclePark(2, 2);
            var truck = new Truck("CA1011AH", "John Smith", 1);
            park.InsertTruck(truck, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            
            var othertruck = new Truck("CA1022AH", "Jane Smith", 1);
            string message = park.InsertTruck(othertruck, 1, 1, new DateTime(2015, 5, 10, 12, 30, 0));
            Assert.AreEqual("The place (1,1) is occupied", message);
        }

        [TestMethod]
        public void Test_InsertTruck_WithSameLicensePlate_ShouldReturnErrorMessage()
        {
            var park = new VehiclePark(2, 2);
            var truck = new Truck("CA1011AH", "John Smith", 1);
            park.InsertTruck(truck, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            
            var otherTruck = new Truck("CA1011AH", "Jane Smith", 1);
            string message = park.InsertTruck(otherTruck, 1, 2, new DateTime(2015, 5, 10, 12, 30, 0));
            Assert.AreEqual("There is already a vehicle with license plate CA1011AH in the park", message);
        }
    }
}
