using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provider.domain.page;
using System.Collections.Generic;

namespace UnitTestClass
{
    [TestClass]
    public class Page
    {
        [TestMethod]
        public void ViewSuppliersTest()
        {
            PageManager pg = new PageManager();
            //Assert.IsInstanceOfType(typeof(List<Page>), pg.pages.GetType());
            //Assert.AreEqual(typeof(List<Page>), pg.pages.GetType());
        }

        [TestMethod]
        public void ViewSupplierInformationTest()
        {
            PageManager pg = new PageManager();
            //Assert.IsInstanceOfType(typeof(Page), pg.GetSupplierPage(pg.pages[0].owner).GetType());
            //Assert.AreEqual(typeof(Page), pg.GetSupplierPage(pg.pages[0].owner).GetType());
            
        }


    }
}
