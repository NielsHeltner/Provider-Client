using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provider.domain.users;

namespace UnitTest.Users
{
    [TestClass]
    public class UsersUnitTest
    {
        [TestMethod]
        public void LogInTrue()
        {
            UserManager userManager = new UserManager();
            Assert.IsTrue(userManager.Validate("Jebisan", "123"));
        }

        [TestMethod]
        public void LogInFalse()
        {
            UserManager userManager = new UserManager();
            Assert.IsFalse(userManager.Validate("Karim", "123"));
        }


    }
}
