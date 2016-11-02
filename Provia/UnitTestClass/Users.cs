using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provider.domain.users;

namespace UnitTestClass
{
    [TestClass]
    public class Users
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
