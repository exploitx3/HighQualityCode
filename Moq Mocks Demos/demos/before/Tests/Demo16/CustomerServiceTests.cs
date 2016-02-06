using Moq;
using NUnit.Framework;
using PluralSight.Moq.Code.Demo16;

namespace PluralSight.Moq.Tests.Demo16
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer
        {
            [Test]
            public void the_address_should_be_formatted()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockAddressFormatterFactory = 
                    new Mock<IAddressFormatterFactory> 
                        {DefaultValue = DefaultValue.Mock};

                var customerService = new CustomerService(
                    mockCustomerRepository.Object, 
                    mockAddressFormatterFactory.Object);

                var addressFormatter = mockAddressFormatterFactory
                    .Object.From(It.IsAny<string>());
                var mock = Mock.Get(addressFormatter);

                //Act

                //Assert
            }
        }
    }
}