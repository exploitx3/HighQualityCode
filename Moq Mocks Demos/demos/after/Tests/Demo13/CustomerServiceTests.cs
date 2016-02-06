using Moq;
using NUnit.Framework;
using PluralSight.Moq.Code.Demo13;

namespace PluralSight.Moq.Tests.Demo13
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_new_customer
        {
            [Test]
            public void an_email_should_be_sent_to_the_sales_team()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockMailingRepository = new Mock<IMailingRepository>();

                var customerService = new CustomerService(
                    mockCustomerRepository.Object, mockMailingRepository.Object);

                //Act
                mockCustomerRepository.Raise(
                    x=>x.NotifySalesTeam += null,
                    new NotifySalesTeamEventArgs("jim"));

                //Assert
                mockMailingRepository.Verify(
                    x => x.NewCustomerMessage(It.IsAny<string>()));
            }
        }
    }
}