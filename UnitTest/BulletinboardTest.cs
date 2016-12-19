using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IO.Swagger.Model;
using Provider.domain;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class BulletinboardTest
    {
        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            Controller.instance.LogIn("Test Supplier", "123");
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
            Assert.AreEqual(PostType.Warning, Controller.instance.ViewWarningPosts()[0].Type);
        }

        [TestMethod]
        public void GetOfferPostsTest()
        {
            Assert.IsNotNull(Controller.instance.ViewOfferPosts());
            Assert.AreEqual(PostType.Offer, Controller.instance.ViewOfferPosts()[0].Type);
        }

        [TestMethod]
        public void GetRequestPostsTest()
        {
            Assert.IsNotNull(Controller.instance.ViewRequestPosts());
            Assert.AreEqual(PostType.Request, Controller.instance.ViewRequestPosts()[0].Type);
        }

        [TestMethod]
        public void CreatePostTest()
        {
            Controller.instance.CreatePost("Provia", "Test Post", "Test Post", PostType.Request);
            Controller.instance.GetPosts();
            Assert.IsNotNull(Controller.instance.ViewRequestPosts().Find(p => p.Owner.Equals("Provia") && p.Title.Equals("Test Post") && p.Description.Equals("Test Post")));
        }
               
        [TestMethod]
        public void EditPostTest()
        {
            Post testPost = Controller.instance.ViewRequestPosts().Find(p => p.Owner.Equals("Provia") && p.Title.Equals("Test Post") && p.Description.Equals("Test Post"));
            Controller.instance.EditPost(testPost, "New Test Post", "New Test Post");
            Controller.instance.GetPosts();
            Assert.IsNotNull(Controller.instance.ViewRequestPosts().Find(p => p.Owner.Equals("Provia") && p.Title.Equals("New Test Post") && p.Description.Equals("New Test Post")));
        }

        [TestMethod]
        public void DeletePostTest()
        {
            Post testPost = Controller.instance.ViewRequestPosts().Find(p => p.Owner.Equals("Provia") && p.Title.Equals("New Test Post") && p.Description.Equals("New Test Post"));
            Assert.IsNotNull(Controller.instance.ViewRequestPosts().Find(p => p.Id == testPost.Id));
            Controller.instance.DeletePost(testPost);
            Controller.instance.GetPosts();
            Assert.IsNull(Controller.instance.ViewRequestPosts().Find(p => p.Id == testPost.Id));
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            Controller.instance.LogOut();
        }

    }
}