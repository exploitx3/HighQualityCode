namespace WebCralwer.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WebCrawler;

    [TestClass]
    public class CrawlerTests
    {
        [TestMethod]
        public void ExtractImageUrls_Should_Return_Collection_Of_Image_Src_Content()
        {
            // Arrange
            var crawler = new Crawler();

            var expectedImageUrls = new[]
            {
                // What to expect?
                "nakov.png",
                "courses/inner/background.jpeg"
            };

            // Act
            var imageUrls = crawler.ExtractImageUrls(string.Empty)
                .ToList();

            
            // Assert
            CollectionAssert.AreEqual(expectedImageUrls, imageUrls);
        }
    }
}
