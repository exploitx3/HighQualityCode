namespace VehicleParkSystem.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models.Vehicles;

    [TestClass]
    public class InsertCarTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void Test_InsertCar_CorrectParameters_ShouldInsertTheCar()
        {
            var park = new VehiclePark(2, 2);
            var car = new Car("CA1011AH", "John Smith", 1);
            string message = park.InsertCar(car, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("Car parked successfully at place (1,1)", message);
        }

        [TestMethod]
        public void Test_InsertCar_FillPark_ShouldInsertAllCars()
        {
            var park = new VehiclePark(2, 1);
            var car = new Car("CA1011AH", "John Smith", 1);
            string message = park.InsertCar(car, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("Car parked successfully at place (1,1)", message);

            var otherCar = new Car("CA1022AH", "Jane Smith", 1);
            message = park.InsertCar(otherCar, 2, 1, new DateTime(2015, 5, 10, 12, 30, 0));
            Assert.AreEqual("Car parked successfully at place (2,1)", message);
        }

        [TestMethod]
        public void Test_InsertCar_IncorrectSector_ShouldReturnErrorMessage()
        {
            var park = new VehiclePark(2, 2);
            var car = new Car("CA1011AH", "John Smith", 1);
            string message = park.InsertCar(car, 10, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("There is no sector 10 in the park", message);
        }

        [TestMethod]
        public void Test_InsertCar_IncorrectPlace_ShouldReturnErrorMessage()
        {
            var park = new VehiclePark(2, 2);
            var car = new Car("CA1011AH", "John Smith", 1);
            string message = park.InsertCar(car, 1, 10, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("There is no place 10 in sector 1", message);
        }

        [TestMethod]
        public void Test_InsertCar_OccupiedPlace_ShouldReturnErrorMessage()
        {
            var park = new VehiclePark(2, 2);
            var car = new Car("CA1011AH", "John Smith", 1);
            park.InsertCar(car, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
           
            var otherCar = new Car("CA1022AH", "Jane Smith", 1);
            string message = park.InsertCar(otherCar, 1, 1, new DateTime(2015, 5, 10, 12, 30, 0));
            Assert.AreEqual("The place (1,1) is occupied", message);
        }

        [TestMethod]
        public void Test_InsertCar_WithSameLicensePlate_ShouldReturnErrorMessage()
        {
            var park = new VehiclePark(2, 2);
            var car = new Car("CA1011AH", "John Smith", 1);
            park.InsertCar(car, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            
            var otherCar = new Car("CA1011AH", "Jane Smith", 1);
            string message = park.InsertCar(otherCar, 1, 2, new DateTime(2015, 5, 10, 12, 30, 0));
            Assert.AreEqual("There is already a vehicle with license plate CA1011AH in the park", message);
        }
    }
}
