namespace VehicleParkSystem.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models.Vehicles;

    [TestClass]
    public class FindVehiclesByOwnerTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void Test_FindVehiclesByOwner_SingleVehicle_ShouldReturnTheVehicle()
        {
            var park = new VehiclePark(1, 1);
            var car = new Car("CA1011AH", "John Smith", 1);
            park.InsertCar(car, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));

            string message = park.FindVehiclesByOwner("John Smith");
            Assert.AreEqual(
                "Car [CA1011AH], owned by John Smith\r\n" +
                "Parked at (1,1)",
                message);
        }

        [TestMethod]
        public void Test_FindVehiclesByOwner_SomeVehiclesMatch_ShouldReturnTheCorrectVehicle()
        {
            var park = new VehiclePark(2, 2);
            var car = new Car("CA1011AH", "John Smith", 1);
            park.InsertCar(car, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            car = new Car("CA3035AH", "Jane Smith", 1);
            park.InsertCar(car, 2, 1, new DateTime(2015, 5, 10, 10, 30, 0));

            string message = park.FindVehiclesByOwner("Jane Smith");
            Assert.AreEqual(
                "Car [CA3035AH], owned by Jane Smith\r\n" +
                "Parked at (2,1)",
                message);
        }

        [TestMethod]
        public void Test_FindVehiclesByOwner_NoVehiclesMatch_ShouldReturnErrorMessage()
        {
            var park = new VehiclePark(2, 2);
            var car = new Car("CA1011AH", "John Smith", 1);
            park.InsertCar(car, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            car = new Car("CA3035AH", "Jane Smith", 1);
            park.InsertCar(car, 2, 1, new DateTime(2015, 5, 10, 10, 30, 0));

            string message = park.FindVehiclesByOwner("Jane Austen");
            Assert.AreEqual("No vehicles by Jane Austen", message);
        }

        [TestMethod]
        public void Test_FindVehiclesByOwner_EmptyPark_ShouldReturnErrorMessage()
        {
            var park = new VehiclePark(2, 2);
            string message = park.FindVehiclesByOwner("Jane Austen");
            Assert.AreEqual("No vehicles by Jane Austen", message);
        }

        [TestMethod]
        public void Test_FindVehiclesByOwner_SomeVehiclesMatch_ShouldSortCorrectly()
        {
            var park = new VehiclePark(3, 3);
            var first = new Car("CA1011AH", "John Smith", 1);
            park.InsertCar(first, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            var second = new Truck("CA2022AH", "John Smith", 1);
            park.InsertTruck(second, 1, 2, new DateTime(2015, 5, 10, 11, 30, 0));
            var third = new Truck("CA9999AH", "John Smith", 1);
            park.InsertTruck(third, 2, 1, new DateTime(2015, 5, 8, 11, 30, 0));
            var fourth = new Motorbike("CA1111AH", "John Smith", 1);
            park.InsertMotorbike(fourth, 2, 2, new DateTime(2015, 5, 8, 11, 30, 0));

            string message = park.FindVehiclesByOwner("John Smith");
            Assert.AreEqual(
                "Motorbike [CA1111AH], owned by John Smith\r\n" +
                "Parked at (2,2)\r\n" +
                "Truck [CA9999AH], owned by John Smith\r\n" +
                "Parked at (2,1)\r\n" +
                "Car [CA1011AH], owned by John Smith\r\n" +
                "Parked at (1,1)\r\n" +
                "Truck [CA2022AH], owned by John Smith\r\n" +
                "Parked at (1,2)",
                message);
        }
    }
}
