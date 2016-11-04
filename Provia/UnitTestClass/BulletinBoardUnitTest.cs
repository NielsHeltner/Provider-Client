using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provider.domain.bulletinboard;
using System.Collections.Generic;

namespace UnitTestClass.bulletinboard
{
    [TestClass]
    public class BulletinBoardUnitTest
    {
        [TestMethod]
        public void ViewBulletinboard()
        {
            Bulletinboard Bb= new Bulletinboard();
            Assert.AreEqual(typeof(List<Post>), Bb.ViewBulletinBoard(0).GetType());
        }
    }
}
