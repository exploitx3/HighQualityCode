namespace VehicleParkSystem.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models.Vehicles;

    [TestClass]
    public class ExitVehicleTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void Test_ExitVehicle_ShouldRemoveTheVehicle()
        {
            var park = new VehiclePark(1, 2);
            var car = new Car("CA1011AH", "John Smith", 1);
            DateTime insertDate = new DateTime(2015, 5, 10, 10, 30, 0);
            park.InsertCar(car, 1, 1, insertDate);
            park.ExitVehicle("CA1011AH", insertDate.AddHours(1), 10.0M);

            string message = park.GetStatus();
            Assert.AreEqual("Sector 1: 0 / 2 (0% full)", message);
        }

        [TestMethod]
        public void Test_ExitVehicle_LessTimeThanReserved_ShouldChargeForTheReservedTime()
        {
            var park = new VehiclePark(1, 2);
            var car = new Car("CA1011AH", "John Smith", 2);
            DateTime insertDate = new DateTime(2015, 5, 10, 10, 0, 0);
            park.InsertCar(car, 1, 1, insertDate);
            string message = park.ExitVehicle("CA1011AH", insertDate.AddHours(1), 10.0M);
            Assert.AreEqual(
                "********************\r\n" +
                "Car [CA1011AH], owned by John Smith\r\n" +
                "at place (1,1)\r\n" +
                "Rate: $4.00\r\n" +
                "Overtime rate: $0.00\r\n" +
                "--------------------\r\n" +
                "Total: $4.00\r\n" +
                "Paid: $10.00\r\n" +
                "Change: $6.00\r\n" +
                "********************",
                message);
        }

        [TestMethod]
        public void Test_ExitVehicle_MoreTimeThanReserved_ShouldChargeOvertime()
        {
            var park = new VehiclePark(1, 2);
            var car = new Car("CA1011AH", "John Smith", 1);
            DateTime insertDate = new DateTime(2015, 5, 10, 10, 0, 0);
            park.InsertCar(car, 1, 1, insertDate);
            string message = park.ExitVehicle("CA1011AH", insertDate.AddHours(2), 10.0M);
            Assert.AreEqual(
                "********************\r\n" +
                "Car [CA1011AH], owned by John Smith\r\n" +
                "at place (1,1)\r\n" +
                "Rate: $2.00\r\n" +
                "Overtime rate: $3.50\r\n" +
                "--------------------\r\n" +
                "Total: $5.50\r\n" +
                "Paid: $10.00\r\n" +
                "Change: $4.50\r\n" +
                "********************",
                message);
        }

        [TestMethod]
        public void Test_ExitVehicle_InvalidLicensePlate_ShouldReturnErrorMessage()
        {
            var park = new VehiclePark(1, 2);
            var car = new Car("CA1011AH", "John Smith", 1);
            DateTime insertDate = new DateTime(2015, 5, 10, 10, 0, 0);
            string message = park.ExitVehicle("CA1011AH", insertDate.AddHours(2), 10.0M);
            Assert.AreEqual("There is no vehicle with license plate CA1011AH in the park", message);
        }

        [TestMethod]
        public void Test_ExitVehicle_AlreadyExited_ShouldReturnErrorMessage()
        {
            var park = new VehiclePark(1, 2);
            var car = new Car("CA1011AH", "John Smith", 1);
            DateTime insertDate = new DateTime(2015, 5, 10, 10, 0, 0);
            park.InsertCar(car, 1, 1, insertDate);
            park.ExitVehicle("CA1011AH", insertDate.AddHours(2), 10.0M);
            string message = park.ExitVehicle("CA1011AH", insertDate.AddHours(2), 10.0M);
            Assert.AreEqual("There is no vehicle with license plate CA1011AH in the park", message);
        }
    }
}
