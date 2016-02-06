using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PluralSight.Moq.Code.Demo05;

namespace PluralSight.Moq.Tests.Demo05
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer
        {
            [Test]
            public void each_customer_should_be_assigned_an_id()
            {
                //Arrange
                var listOfCustomersToCreate = new List<CustomerToCreateDto>
                                                  {
                                                      new CustomerToCreateDto(),
                                                      new CustomerToCreateDto()
                                                  };

                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockIdFactory = new Mock<IIdFactory>();


                var customerService = new CustomerService(
                    mockCustomerRepository.Object, mockIdFactory.Object);

                //Act
                customerService.Create(listOfCustomersToCreate);

                //Assert
                mockIdFactory.Verify(x => x.Create(), Times.AtLeastOnce());
            }
        }
    }
}