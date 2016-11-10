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
        public void SearchTest() // TODO: lav denne test bedre
        {
            PageManager pm = new PageManager();
            var page1 = new Page("DSM Nutritional Products Ltd");
            page1.products.Add(new Product(01, "ROVIMIX®B1", "ROVIMIX® B1 is a white to yellowish fine granular powder of pure thiamine mononitrate.", 2000, "Sæk", "4-methyl-5-(β-hydroxyethyl)-3-(2-methyl-4-amino-5-pyrimidyl)-thiazoliumnitrateW", 327.36, new DateTime(2017, 03, 15, 03, 30, 00)));
            var page2 = new Page("Fenchem Biotek Ltd");
            page2.products.Add(new Product(02, "Folic Acid", "Folic acid is also referred to as vitamin M, vitamin B9, vitamin Bc (or folacin), pteroyl-L-glutamic acid, and pteroyl-L-glutamate. It is an essential material for the body when using sugars and amino acids. As an important carbon carrier, folic acid is playing an important role in the synthesis of nucleotide, re-methylation of homocysteine and many other important physiological functions.", 4000, "Tønder", "N-4-[(2-Amido-4-oxo-1,4-dihydro-6-terene)methylamino]benzoyl-L-glutamic acid", 441.4, new DateTime(2017, 03, 15, 03, 30, 00)));
            var page3 = new Page("Chr.Olesen Nutrition A/S");
            page3.products.Add(new Product(03, "VITAMIN B1 Mononitrate", "White or almost white crystalline powder", 1500, "Palle", "N/A", 0, new DateTime(2017, 03, 15, 03, 30, 00)));
            pm.pages.Add(page1);
            pm.pages.Add(page2);
            pm.pages.Add(page3);
            Assert.AreEqual("Chr.Olesen Nutrition A/S", pm.Search("chr")[0].owner);
            Assert.AreEqual("DSM Nutritional Products Ltd", pm.Search("DSM")[0].owner);
            Assert.AreEqual(2, pm.Search("Ltd").Count);
            Assert.AreEqual("DSM Nutritional Products Ltd", pm.Search("rovimix")[0].owner);
            Assert.AreEqual(2, pm.Search("B1").Count);
            Assert.AreEqual(1, pm.Search("Acid").Count);
        }

    }
}
