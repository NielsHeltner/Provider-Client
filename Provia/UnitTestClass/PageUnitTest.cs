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
            PageManager pm = new PageManager();
            Assert.AreEqual(typeof(List<Provider.domain.page.Page>), pm.pages.GetType());
        }

        [TestMethod]
        public void SearchTest() // TODO: skal muligvis laves om, så den tester resultatet i stedet for typen
        {
            PageManager pm = new PageManager();
            Assert.AreEqual(typeof(List<Provider.domain.page.Page>), pm.Search("e").GetType());
        }

    }
}
