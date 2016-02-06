using Moq;
using NUnit.Framework;
using PluralSight.Moq.Code.Demo07;

namespace PluralSight.Moq.Tests.Demo07
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_platinum_status_customer
        {
            [Test]
            public void a_special_save_routine_should_be_used()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockCustomerStatusFactory = new Mock<ICustomerStatusFactory>();

                var customerToCreate = new CustomerToCreateDto
                                           {
                                               DesiredStatus = CustomerStatus.Bronze, 
                                               FirstName = "Bob", 
                                               LastName = "Builder"
                                           };

                mockCustomerStatusFactory.Setup(
                    x => x.CreateFrom(
                        It.Is<CustomerToCreateDto>(
                            y => y.DesiredStatus == CustomerStatus.Platinum)))
                    .Returns(CustomerStatus.Platinum);


                var customerService = new CustomerService(
                    mockCustomerRepository.Object, mockCustomerStatusFactory.Object);

                //Act
                customerService.Create(customerToCreate);

                //Assert
                mockCustomerRepository.Verify(
                    x=>x.SaveSpecial(It.IsAny<Customer>()));
            }
        }
    }
}