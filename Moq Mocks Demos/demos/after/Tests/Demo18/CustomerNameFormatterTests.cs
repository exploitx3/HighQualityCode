using Moq;
using Moq.Protected;
using NUnit.Framework;
using PluralSight.Moq.Code.Demo18;

namespace PluralSight.Moq.Tests.Demo18
{
    public class CustomerNameFormatterTests
    {
        [TestFixture]
        public class When_formatting_a_customers_name
        {
            [Test]
            public void all_bad_words_should_be_scrubbed()
            {
                //Arrange
                var mockCustomerNameFormatter = new Mock<CustomerNameFormatter>();

                mockCustomerNameFormatter.Protected()
                    .Setup<string>("ParseBadWordsFrom", ItExpr.IsAny<string>())
                    .Returns("asdf")
                    .Verifiable();

                //Act
                mockCustomerNameFormatter.Object.From(new Customer());

                //Assert
                mockCustomerNameFormatter.Verify();
            }
        }
    }
}