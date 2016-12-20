using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IO.Swagger.Model;
using Provider.domain;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UserTest
    {
        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            Controller.instance.LogOut();
        }

        [TestMethod]
        public void LoginTest()
        {
            bool login = Controller.instance.LogIn("Test Supplier", "123");
            Assert.IsTrue(login);
        }

        [TestMethod]
        public void GetLoggedInUserTest()
        {
            User testUser = new User("Test Supplier", User.RightsEnum.Supplier);
            Assert.AreEqual(testUser, Controller.instance.GetLoggedInUser());
        }

        [TestMethod]
        public void LogoutTest()
        {
            Controller.instance.LogOut();
            Assert.IsNull(Controller.instance.GetLoggedInUser());
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            Controller.instance.LogOut();
        }

    }
}