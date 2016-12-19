using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IO.Swagger.Model;
using Provider.domain;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class PageTest
    {
        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            Controller.instance.LogIn("Test Supplier", "123");
        }

        [TestMethod]
        public void GetPagesTest()
        {
            Assert.IsNotNull(Controller.instance.GetPages());
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
            Assert.IsNotNull(testPage.Find(page => page.Owner.Contains("Chr")));
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
                Controller.instance.GetSuppliers();
                testPage = Controller.instance.GetPages().Find(p => p.Owner.Equals("Test Supplier"));
                Assert.IsNotNull(testPage.Note);
            }
            else
            {
                Controller.instance.AddNoteToSupplier("Test Supplier", "Test Supplier", "More Test Text");
                testPage = null;
                testNote = null;
                Controller.instance.GetSuppliers();
                testPage = Controller.instance.GetPages().Find(p => p.Owner.Equals("Test Supplier"));
                testNote = testPage.Note;
                Assert.AreEqual("More Test Text", testNote.Text);
            }
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
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