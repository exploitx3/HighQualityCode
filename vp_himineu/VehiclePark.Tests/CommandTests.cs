namespace VehiclePark.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using Core;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Models.Layouts;
    using Models.Vehicles;
    using Moq;

    [TestClass]
    public class CommandTests
    {
        private IVehiclePark vehiclePark;
        private Car testCar = new Car("OV4444AR", "BashShefa", 5);
        private Database database;
        private Layout layout;
        private Mock<IDatabase> databaseMock = new Mock<IDatabase>();

        [TestInitialize]
        public void VehicleParkInitialize()
        {
            //Arrange
            this.layout = new Layout(5, 5);
            this.database = new Database(5);
            this.vehiclePark = new VehiclePark(this.layout, this.database);
//            this.databaseMock.Setup(m => m.OwnerNames.ContainsKey(It.IsAny<string>())).Returns(true);
            this.databaseMock.Setup(d => d.OwnerNames[It.IsAny<string>()]).Returns(new List<IVehicle>{ this.testCar});

        }

        [TestMethod]
        public void TestInsertCar_ShouldInsertCar()
        {
            //Arrange
            string vehicleString = $"{this.testCar.ToString()}{Environment.NewLine}Parked at ({2},{2})";
            //Act
            var result = this.vehiclePark.InsertCar(this.testCar, 2, 2, DateTime.Now);

            //Assert
            Assert.AreEqual("Car parked successfully at place (2,2)", result);
            Assert.AreEqual(vehicleString, this.vehiclePark.FindVehicle("OV4444AR"));
        }

        [TestMethod]
        public void TestInsertCar_InvalidSector()
        {
            //Act
            var result = this.vehiclePark.InsertCar(this.testCar, 6, 2, DateTime.Now);

            //Assert
            Assert.AreEqual("There is no sector 6 in the park", result);
        }

        [TestMethod]
        public void TestInsertCar_InvalidPlace()
        {
            //Act
            var result = this.vehiclePark.InsertCar(this.testCar, 2, 6, DateTime.Now);

            //Assert
            Assert.AreEqual("There is no place 6 in sector 2", result);
        }

        [TestMethod]
        public void TestInsertCar_PlaceAlreadyOccupied()
        {
            //Act
            this.vehiclePark.InsertCar(this.testCar, 2, 2, DateTime.Now);
            var result = this.vehiclePark.InsertCar(this.testCar, 2, 2, DateTime.Now);

            //Assert
            Assert.AreEqual("The place (2,2) is occupied", result);
        }

        [TestMethod]
        public void TestInsertCar_AddVehicleWithAlreadyContainedLicensePlate_ShouldReportAnError()
        {
            //Act
            this.vehiclePark.InsertCar(this.testCar, 2, 2, DateTime.Now);
            var result = this.vehiclePark.InsertCar(this.testCar, 3, 2, DateTime.Now);

            //Assert
            Assert.AreEqual($"There is already a vehicle with license plate {this.testCar.LicensePlate} in the park", result);
        }

        [TestMethod]
        public void TestExitVehicle_NotContainedVehicle_ShouldReportAnError()
        {
            //Act
            var result = this.vehiclePark.ExitVehicle(this.testCar.LicensePlate, DateTime.Now, 10);

            //Assert
            Assert.AreEqual($"There is no vehicle with license plate {this.testCar.LicensePlate} in the park", result);
        }

        [TestMethod]
        public void TestExitVehicle_SuccessfullyExittedVehicle()
        {
            //Arrange
            decimal moneyPaid = 50;
            DateTime startTime = DateTime.Now;
           
            //Act
            this.vehiclePark.InsertCar(this.testCar, 2, 2, startTime);
            

            var totalHoursStayed = (int)Math.Round((startTime.AddHours(2) - this.database.VehicleArrivalTime[this.testCar]).TotalHours);
            var overTimeRate = totalHoursStayed > this.testCar.ReservedHours
               ? (totalHoursStayed - this.testCar.ReservedHours) * this.testCar.OvertimeRate
               : 0;

            var totalCharged = (this.testCar.ReservedHours * this.testCar.RegularRate + (overTimeRate));

            StringBuilder expectedResult = new StringBuilder().AppendLine(new string('*', 20))
                .AppendFormat("{0}", this.testCar)
                .AppendLine()
                .AppendFormat($"at place (2,2)")
                .AppendLine()
                .AppendFormat("Rate: ${0:F2}", this.testCar.ReservedHours * this.testCar.RegularRate)
                .AppendLine()
                .AppendFormat("Overtime rate: ${0:F2}", overTimeRate)
                .AppendLine()
                .AppendLine(new string('-', 20))
                .AppendFormat("Total: ${0:F2}", totalCharged)
                .AppendLine()
                .AppendFormat("Paid: ${0:F2}", moneyPaid)
                .AppendLine()
                .AppendFormat("Change: ${0:F2}",
                    moneyPaid - totalCharged).AppendLine().Append(new string('*', 20));

            var result = this.vehiclePark.ExitVehicle(this.testCar.LicensePlate, startTime.AddHours(2), 50);
            //Assert
            Assert.AreEqual(result, expectedResult.ToString());
        }

        [TestMethod]
        public void TestGetStatus_ShouldReturnCorrectResult()
        {
            //Arrange
            this.vehiclePark.InsertCar(this.testCar, 3, 2, DateTime.Now);
            this.vehiclePark.InsertCar(this.testCar, 2, 2, DateTime.Now);
            this.vehiclePark.InsertCar(this.testCar, 1, 2, DateTime.Now);


            var places = this.database
                .SectorsCount
                .Select((placesCount, sectorIndex) => string.Format(
                    "Sector {0}: {1} / {2} ({3}% full)",
                    sectorIndex + 1,
                    placesCount,
                    this.layout.PlacesPerSector,
                    Math.Round((double)placesCount / this.layout.PlacesPerSector * 100)));
            //Act
            var expectedResult = string.Join(Environment.NewLine, places);
            var result = this.vehiclePark.GetStatus();
            //Assert
            Assert.AreEqual(result, expectedResult.ToString());
        }

        [TestMethod]
        public void TestFindVehicleByOwner_ShouldReturnCorrectResult()
        {
            //Arrange

            var mockedPark = new VehiclePark(this.layout, this.databaseMock.Object);

            var found = this.databaseMock.Object.OwnerNames[this.testCar.Owner].ToList().OrderBy(v => this.database.VehicleArrivalTime[v]).ThenBy(v => v.LicensePlate);

            //Act
            var expectedResult = string.Join(Environment.NewLine, this.Input(found));

            var result = mockedPark.FindVehiclesByOwner(this.testCar.Owner);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestFindVehicleByOwner_EmptyDatabase_ShouldReturnWrongResult()
        {
            //Act
            var result = this.vehiclePark.FindVehiclesByOwner(this.testCar.Owner);
            var expectedResult = string.Format($"No vehicles by {this.testCar.Owner}");
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        private string Input(IEnumerable<IVehicle> vehicles)
        {
            return string.Join(Environment.NewLine,
             vehicles.Select(
                 vehicle =>
                     string.Format("{0}{1}Parked at {2}",
                         vehicle.ToString(),
                         Environment.NewLine,
                         this.database.CarParkingPlaceByCar[vehicle])));
        }
    }
}
