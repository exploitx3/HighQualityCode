using Moq;
using NUnit.Framework;
using PluralSight.Moq.Code.Demo09;

namespace PluralSight.Moq.Tests.Demo09
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer
        {
            [Test]
            public void the_local_timezone_should_be_set()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();

                var customerService = new CustomerService(
                    mockCustomerRepository.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockCustomerRepository.VerifySet(
                    x=>x.LocalTimeZone = It.IsAny<string>());
            }
        }
    }
}