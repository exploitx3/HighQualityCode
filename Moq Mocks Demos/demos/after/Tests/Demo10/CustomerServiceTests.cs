using Moq;
using NUnit.Framework;
using PluralSight.Moq.Code.Demo10;

namespace PluralSight.Moq.Tests.Demo10
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer
        {
            [Test]
            public void the_workstation_id_should_be_used()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockApplicationSettings = new Mock<IApplicationSettings>();

                mockApplicationSettings.Setup(x => x.WorkstationId).Returns(123);
                
                var customerService = new CustomerService(
                    mockCustomerRepository.Object, 
                    mockApplicationSettings.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockApplicationSettings.VerifyGet(x=>x.WorkstationId);
            }
        }
    }
}