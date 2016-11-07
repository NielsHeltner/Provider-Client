using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provider.domain.page;
using Provider.domain.users;
using System.Collections.Generic;

namespace UnitTestClass.page
{
    [TestClass]
    public class PageUnitTest
    {

        [TestMethod]
        public void SearchTest() // TODO: skal også teste på produkter
        {
            PageManager pm = new PageManager();
            pm.pages.Add(new Page(new Supplier("DSM Nutritional Products Ltd", "somepswd")));
            pm.pages.Add(new Page(new Supplier("Fenchem Biotek Ltd", "somepswd")));
            pm.pages.Add(new Page(new Supplier("Chr.Olesen Nutrition A/S", "somepswd")));
            Assert.AreEqual("Chr.Olesen Nutrition A/S",pm.Search("chr")[0].name);
            Assert.AreEqual("DSM Nutritional Products Ltd", pm.Search("DSM")[0].name);
            Assert.AreEqual(2, pm.Search("Ltd").Count);
        }

    }
}
