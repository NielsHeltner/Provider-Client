using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provider.domain.users;

namespace UnitTest.users
{
    [TestClass]
    public class UserUnitTest
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

        [TestMethod]
        public void CheckIfUserIsLoggedIn()
        {
            UserManager userManager = new UserManager();
            userManager.Validate("Jebisan", "123");
            Assert.IsNotNull(userManager.loggedInUser);
        }

        [TestMethod]
        public void CheckIfUserIsLoggedOut()
        {
            UserManager userManager = new UserManager();
            userManager.Validate("Jebisan", "123");
            userManager.LogOut(); 
            Assert.IsNull(userManager.loggedInUser);
        }
        
    }
}
