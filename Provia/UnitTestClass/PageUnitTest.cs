using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provider.domain.page;
using System.Collections.Generic;

namespace UnitTestClass.page
{
    [TestClass]
    public class PageUnitTest
    {
        [TestMethod]
        public void ViewSuppliersTest()
        {
            PageManager pg = new PageManager();
            Assert.AreEqual(typeof(List<Provider.domain.page.Page>), pg.pages.GetType());
        }

        [TestMethod]
        public void ViewSupplierInformationTest()
        {
            PageManager pg = new PageManager();
            Assert.AreEqual(typeof(Provider.domain.page.Page), pg.GetSupplierPage(pg.pages[0].owner).GetType());
        }

    }
}
