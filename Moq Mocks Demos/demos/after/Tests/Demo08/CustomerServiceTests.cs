using Moq;
using NUnit.Framework;
using PluralSight.Moq.Code.Demo08;

namespace PluralSight.Moq.Tests.Demo08
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer_which_has_an_invalid_address
        {
            [Test]
            [ExpectedException(typeof(CustomerCreationException))]
            public void an_exception_should_be_raised()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockCustomerAddressFactory = new Mock<ICustomerAddressFactory>();

                mockCustomerAddressFactory
                    .Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
                    .Throws<InvalidCustomerAddressException>();

                var customerService = new CustomerService(
                    mockCustomerRepository.Object, 
                    mockCustomerAddressFactory.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
            }
        }
    }
}