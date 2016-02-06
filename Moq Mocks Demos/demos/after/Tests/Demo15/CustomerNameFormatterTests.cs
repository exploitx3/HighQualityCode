using Moq;
using NUnit.Framework;
using PluralSight.Moq.Code.Demo15;

namespace PluralSight.Moq.Tests.Demo15
{
    public class CustomerNameFormatterTests
    {
        [TestFixture]
        public class When_formatting_a_customers_name
        {
            [Test]
            public void bad_words_should_be_stripped_from_the_first_and_last_names()
            {
                //Arrange
                var mockNameFormatter = new Mock<CustomerNameFormatter>();

                //Act
                mockNameFormatter.Object.From(new Customer("Bob", "SAPBuilder"));

                //Assert
                mockNameFormatter.Verify(
                    x=>x.ParseBadWordsFrom(It.IsAny<string>()),
                    Times.Exactly(2));
            }
        }
    }
}