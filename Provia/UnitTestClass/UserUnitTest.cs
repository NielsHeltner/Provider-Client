using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provider.domain;

namespace UnitTestClass.users
{
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public void LogInTrue()
        {
            Assert.IsTrue(Controller.instance.LogIn("Provia", "123"));
        }

        [TestMethod]
        public void LogInFalse()
        {
            Assert.IsFalse(Controller.instance.LogIn(" ", " "));
        }

        [TestMethod]
        public void CheckIfUserIsLoggedIn()
        {
            Controller.instance.LogIn("Provia", "123");
            Assert.IsNotNull(Controller.instance.GetLoggedInUser());
        }

        [TestMethod]
        public void CheckIfUserIsLoggedOut()
        {
            Controller.instance.LogIn("Provia", "123");
            Controller.instance.LogOut();
            Assert.IsNull(Controller.instance.GetLoggedInUser());
        }
        
    }
}
