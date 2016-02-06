using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChepelareHotelBookingSystem.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using Controllers;
    using Data;
    using HotelBookingSystem.Models;
    using Identity;
    using Interfaces;
    using Models;
    using Moq;

    [TestClass]
    public class ChepelareHotelBookingSystemTests
    {
        [TestMethod]
        public void RepositoryGet_ShoudReturnItemById()
        {
            var repository = new Repository<IDbEntity>();

            repository.Add(new User("usernammee", "Password", Roles.User));
            repository.Add(new User("usernamme1e", "Passwo2rd", Roles.User));

            Assert.AreEqual(1, repository.Get(1).Id);
            Assert.AreEqual(2, repository.Get(2).Id);
        }

        [TestMethod]
        public void RepositoryGet_NotExistentId_ShoudReturnNull()
        {
            var repository = new Repository<IDbEntity>();

            repository.Add(new User("usernammee", "Password", Roles.User));

            Assert.IsNull(repository.Get(4));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ControllerAuthorize_HasNoCurrentUser_ShouldThrowException()
        {
            var testController = new UsersController(new HotelBookingSystemData(), null);
            testController.Authorize(Roles.VenueAdmin);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void ControllerAuthorize_IncorrectAuthorizationAccess_ShouldThrowException()
        {
            var testController = new UsersController(new HotelBookingSystemData(),
                new User("NormalUser", "122343434", Roles.User));
            testController.Authorize(Roles.VenueAdmin);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UsersLogout_NotLoggedInUser_ShouldThrowException()
        {
            var testController = new UsersController(new HotelBookingSystemData(), null);
            testController.Logout();
        }

        [TestMethod]
        public void UsersLogout_SuccessfullyLogout_ShouldReturnView()
        {
            var currentUser = new User("NormalUser", "122343434", Roles.User);
            var testController = new UsersController(new HotelBookingSystemData(), currentUser);

            var resultView = testController.Logout();

            Assert.AreEqual(currentUser, resultView.Model);
        }

        [TestMethod]
        public void VenuesAll_shouldReturnAllVenuesInDatabase()
        {
            var currentUser = new User("NormalUser", "122343434", Roles.VenueAdmin);

            var venuesController = new VenuesController(new HotelBookingSystemData(), currentUser);

            var venue = new Venue("SinCity", "SofiqNqkadeSi", string.Empty, currentUser);

            venuesController.Add("SinCity", "SofiqNqkadeSi", string.Empty);

            var result = venuesController.All().Display();

            StringBuilder expectedViewResult = new StringBuilder();
            expectedViewResult.AppendFormat("*[{0}] {1}, located at {2}", 1, venue.Name, venue.Address)
                .Append(Environment.NewLine)
                .AppendFormat("Free rooms: {0}", venue.Rooms.Count).Append(Environment.NewLine);

            Assert.AreEqual(expectedViewResult.ToString().Trim(), result);
        }

        [TestMethod]
        public void VenuesAll_EmptyDatabase_ShouldReturnCorrectMessage()
        {
            var currentUser = new User("NormalUser", "122343434", Roles.VenueAdmin);

            var venuesController = new VenuesController(new HotelBookingSystemData(), currentUser);

            var result = venuesController.All().Display();


            Assert.AreEqual("There are currently no venues to show.", result);
        }

        [TestMethod]
        public void TestRoomAdd_ValidRoomDetails_RoomShouldBePresent()
        {
            const string expected = "The room with ID 2 has been created successfully.";

            var userMock = new Mock<User>();
            var user = new User("admin", "admin423", Roles.VenueAdmin);
            int nextid = 1;

            var roomRepositoryMock = new Mock<IRepository<Room>>();
            roomRepositoryMock.Setup(
                b => b.Add(It.IsAny<Room>())).Callback((Room r) => r.Id = nextid++);
            var venueRepository = new Mock<IRepository<Venue>>();
            venueRepository.Setup(v => v.Get(It.IsAny<int>()))
                .Returns(new Venue("Venue1", "Sofiq", "Descr", user));

            var mockData = new Mock<IHotelBookingSystemData>();
            mockData.Setup(d => d.RepositoryWithRooms).Returns(roomRepositoryMock.Object);
            mockData.Setup(d => d.RepositoryWithVenues).Returns(venueRepository.Object);

            var controller = new RoomsController(mockData.Object, user);

            controller.Add(1, 100, 100M);
            var result = controller.Add(2, 100, 100M);

            Assert.AreEqual(expected, result.Display());
        }
    }
}
