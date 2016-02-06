using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuhtigIssueTracker.Tests
{
    [TestClass]
    public class RegisterUserTests
    {
        [TestMethod]
        public void Test_RegisterUser_ShouldRegisterTheUser()
        {
            string userName = "validUsername";
            string password = "validPassword";
            
            var tracker = new BuhtigIssueTracker();
            string viewResult = tracker.RegisterUser(userName, password, password);

            Assert.AreEqual($"User {userName} registered successfully", viewResult);
        }
    }
}
