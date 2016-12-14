using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IO.Swagger.Model;
using Provider.domain;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class ProviderClientUnitTest
    {
        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            Controller.instance.LogIn("Test Supplier", "1");
        }

        [TestMethod]
        public void LoginTest()
        {
            bool login = Controller.instance.LogIn("Test Supplier", "1");
            Assert.IsTrue(login);
        }

        [TestMethod]
        public void GetLoggedInUserTest()
        {
            User testUser = new User("Test Supplier", User.RightsEnum.Supplier);

            // Test if logged in user have the right parameters
            Assert.AreEqual(testUser, Controller.instance.GetLoggedInUser());
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

        [TestMethod]
        public void CreateProductTest()
        {
            Controller.instance.CreateProduct("Test Product", "Test Product", 1, "Test Product", 1, "Test Product", "Test Product", "Test Supplier");
            Controller.instance.GetSuppliers();
            Assert.IsNotNull(Controller.instance.GetPages().Find(p => p.Owner.Equals("Test Supplier")).Products.Find(prod => prod.ProductName.Equals("Test Product")));
        }

        [TestMethod]
        public void EditProductTest()
        {
            Product testProduct = Controller.instance.GetPages().Find(p => p.Owner.Equals("Test Supplier")).Products.Find(prod => prod.ProductName.Equals("Test Product"));
            Controller.instance.EditProduct(testProduct, "New Test Product", "New Test Product", 2, "New Test Product", 2, "New Test Product", "New Test Product");
            Controller.instance.GetSuppliers();
            Assert.IsNotNull(Controller.instance.GetPages().Find(p => p.Owner.Equals("Test Supplier")).Products.Find(prod => prod.Id == testProduct.Id));
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            Product testProduct = Controller.instance.GetPages().Find(p => p.Owner.Equals("Test Supplier")).Products.Find(prod => prod.ProductName.Equals("New Test Product"));
            Assert.IsNotNull(testProduct);
            Controller.instance.DeleteProduct(testProduct);
            Controller.instance.GetSuppliers();
            Assert.IsNull(Controller.instance.GetPages().Find(p => p.Owner.Equals("Test Supplier")).Products.Find(prod => prod.Id == testProduct.Id));
        }

        [TestMethod]
        public void SearchTest()
        {
            List<Page> testPage = Controller.instance.Search("chr");
            Assert.AreEqual(1, testPage.Count);

            Assert.AreEqual("Chr. Olesen Nutrition A/S", testPage[0].Owner);
        }

        [TestMethod]
        public void ManageSupplierPageTest()
        {
            Page testPage = Controller.instance.GetPages().Find(p => p.Owner.Equals("Test Supplier"));
            testPage.Description = "Test Description";
            testPage.ContactInformation = "";
            testPage.Note = null;
            testPage.Location = "";
            Controller.instance.ManageSupplierPage(testPage);
            testPage = null;
            Controller.instance.GetSuppliers();
            testPage = Controller.instance.GetPages().Find(p => p.Owner.Equals("Test Supplier"));
            Assert.AreEqual("Test Description", testPage.Description);
        }

        [TestMethod]
        public void AddNoteTest()
        {
            Page testPage = Controller.instance.GetPages().Find(p => p.Owner.Equals("Test Supplier"));
            Note testNote = testPage.Note;
            if(testNote == null)
            {
                Controller.instance.AddNoteToSupplier("Test Supplier", "Test Supplier", "Test Text");
                testPage = null;
                Controller.instance.GetSuppliers(); //update cache
                testPage = Controller.instance.GetPages().Find(p => p.Owner.Equals("Test Supplier"));
                Assert.IsNotNull(testPage.Note);
            }
            else
            {
                Controller.instance.AddNoteToSupplier("Test Supplier", "Test Supplier", "More Test Text");
                testPage = null;
                testNote = null;
                Controller.instance.GetSuppliers(); //update cache
                testPage = Controller.instance.GetPages().Find(p => p.Owner.Equals("Test Supplier"));
                testNote = testPage.Note;
                Assert.AreEqual("More Test Text", testNote.Text);
            }
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
            Controller.instance.LogIn("Test Supplier", "1");
            Page testPage = Controller.instance.GetPages().Find(p => p.Owner.Equals("Test Supplier"));
            testPage.Description = "";
            testPage.ContactInformation = "";
            testPage.Note = null;
            testPage.Location = "";
            Controller.instance.ManageSupplierPage(testPage);
            Controller.instance.AddNoteToSupplier("Test Supplier", "Test Supplier", "");
            Controller.instance.LogOut();
        }

    }
}