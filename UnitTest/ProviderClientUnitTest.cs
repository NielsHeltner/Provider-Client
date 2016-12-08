using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IO.Swagger.Model;
using Provider.domain;

namespace UnitTest
{
    [TestClass]
    public class ProviderClientUnitTest
    {
        [TestInitialize]
        public void SetUp()
        {
            Controller.instance.LogIn("Provia", "123");
        }

        [TestMethod]
        public void LoginTest()
        {
            bool login = Controller.instance.LogIn("Niclas", "123");
            Assert.IsTrue(login);
        }

        [TestMethod]
        public void GetLoggedInUserTest()
        {
            User testUser = new User("Provia", User.RightsEnum.Provia);

            // Test if logged in user have the right parameters
            Assert.AreEqual(Controller.instance.GetLoggedInUser(), testUser);
        }

        [TestMethod]
        public void LogoutTest()
        {
            Controller.instance.LogOut();
            Assert.IsNull(Controller.instance.GetLoggedInUser());
        }

        [TestMethod]
        public void GetPagesTest()
        {
            Assert.IsNotNull(Controller.instance.GetPages());
        }

        [TestMethod]
        public void GetPostsTest()
        {
            Assert.IsNotNull(Controller.instance.ViewAllPosts());
        }

        [TestMethod]
        public void GetWarningPostsTest()
        {
            Assert.IsNotNull(Controller.instance.ViewWarningPosts());

            Assert.AreEqual(Controller.instance.ViewWarningPosts()[0].Type, PostType.Warning);
        }

        [TestMethod]
        public void GetOfferPostsTest()
        {
            Assert.IsNotNull(Controller.instance.ViewOfferPosts());

            Assert.AreEqual(Controller.instance.ViewOfferPosts()[0].Type, PostType.Offer);
        }

        [TestMethod]
        public void GetRequestPostsTest()
        {
            Assert.IsNotNull(Controller.instance.ViewRequestPosts());

            Assert.AreEqual(Controller.instance.ViewRequestPosts()[0].Type, PostType.Request);
        }

    }
}