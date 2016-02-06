using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelAgency.Tests
{
    using Core;
    using Enums;
    using Models;

    [TestClass]
    public class TravelAgencyCatalogTests
    {
        private TicketCatalog catalog;

        [TestInitialize]
        public void CatalogInitialize()
        {
            this.catalog = new TicketCatalog();
        }

        [TestMethod]
        public void AddAirTicket_ShouldAddTicket()
        {

            var result = catalog.AddAirTicket("FX215", "Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 0), 200M);

            Assert.AreEqual("Ticket added", result);
        }

        [TestMethod]
        public void DeleteAirTicket_ShouldDeleteTicket()
        {
            this.catalog.AddAirTicket("FX215", "Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 0), 200M);

            var result = this.catalog.DeleteAirTicket("FX215");

            Assert.AreEqual("Ticket deleted", result);
        }

        [TestMethod]
        public void AddTrainTicket_ShouldAddTicket()
        {
            var result = catalog.AddTrainTicket("Sofia", "Athens", new DateTime(2015, 1, 17, 12, 20, 0), 200M, 300M);

            Assert.AreEqual("Ticket added", result);
        }

        [TestMethod]
        public void DeleteTrainTicket_ShouldDeleteTicket()
        {
            this.catalog.AddTrainTicket("Sofia", "Athens", new DateTime(2015, 1, 17, 12, 20, 0), 200M, 300M);

            var result = this.catalog.DeleteTrainTicket("Sofia", "Athens", new DateTime(2015, 1, 17, 12, 20, 0));

            Assert.AreEqual("Ticket deleted", result);
        }

        [TestMethod]
        public void AddBusTicket_ShouldAddTicket()
        {
            var result = this.catalog.AddBusTicket("Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 0), 200M);

            Assert.AreEqual("Ticket added", result);
        }

        [TestMethod]
        public void DeleteBusTicket_ShouldDeleteTicket()
        {
            this.catalog.AddBusTicket("Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 0), 200M);

            var result = this.catalog.DeleteBusTicket("Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 0));

            Assert.AreEqual("Ticket deleted", result);
        }

        [TestMethod]
        public void FindTickets_ShouldReturnCorrectTickets()
        {
            this.catalog.AddBusTicket("Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 0), 200M);
            this.catalog.AddBusTicket("Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 15, 12, 20, 0), 200M);

            var result = this.catalog.FindTickets("Sofia", "Athens");

            Assert.AreEqual("[15.01.2015 12:20; bus; 200.00] [17.01.2015 12:20; bus; 200.00]", result);
        }

        [TestMethod]
        public void FindTickets_EmptyData_ShouldReturnCorrectTickets()
        {

            var result = this.catalog.FindTickets("Sofia", "Athens");

            Assert.AreEqual(Constants.NotFoundMessage, result);
        }

        [TestMethod]
        public void FindTicketsInterval_ShouldReturnCorrectTickets()
        {
            this.catalog.AddBusTicket("Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 0), 200M);
            this.catalog.AddBusTicket("Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 15, 12, 20, 0), 200M);

            var result = this.catalog.FindTicketsInInterval(
                new DateTime(2015, 1, 15, 12, 20, 0),
                new DateTime(2015, 1, 17, 12, 20, 0));

            Assert.AreEqual("[15.01.2015 12:20; bus; 200.00] [17.01.2015 12:20; bus; 200.00]", result);
        }

        [TestMethod]
        public void FindTicketsInterval_EmptyData_ShouldReturnCorrectTickets()
        {

            var result = this.catalog.FindTicketsInInterval(DateTime.Now, DateTime.Now.AddDays(2));

            Assert.AreEqual(Constants.NotFoundMessage, result);
        }

        [TestMethod]
        public void GetTicketsCount_AirTickets_ShouldReturnCorrectCount()
        {
            this.catalog.AddAirTicket("FX2115", "Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 0), 200M);
            this.catalog.AddAirTicket("FX215", "Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 0), 200M);

            var result = this.catalog.GetTicketsCount(TicketType.Air);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GetTicketsCount_TrainTickets_ShouldReturnCorrectCount()
        {
            this.catalog.AddTrainTicket("Sofia", "Athens", new DateTime(2015, 1, 17, 12, 20, 0), 200M, 300M);
            this.catalog.AddTrainTicket("Sofia", "Athens", new DateTime(2015, 1, 7, 12, 20, 0), 200M, 300M);

            var result = this.catalog.GetTicketsCount(TicketType.Train);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GetTicketsCount_BusTickets_ShouldReturnCorrectCount()
        {
            this.catalog.AddBusTicket("Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 0), 200M);
            this.catalog.AddBusTicket("Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 7, 12, 20, 0), 200M);

            var result = this.catalog.GetTicketsCount(TicketType.Bus);

            Assert.AreEqual(2, result);
        }
    }
}
