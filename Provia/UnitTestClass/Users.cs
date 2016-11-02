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

        [TestMethod]
        public void CheckIfUserIsLoggedInUser()
        {
            
            UserManager userManager = new UserManager();
            userManager.Validate("Jebisan","123");
            Assert.AreEqual("Jebisan",userManager.LoggedInUser.userName);
        }

        [TestMethod]
        public void CheckIfUserIsNotLoggedInUser()
        {

            UserManager userManager = new UserManager();
            Assert.AreNotEqual("Karim", userManager.LoggedInUser.userName);
        }



    }
}
