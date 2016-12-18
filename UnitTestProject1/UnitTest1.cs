using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumExample;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1: BaseTestClass
    {

        [TestProperty("browserName", "Chrome")]
        [TestProperty("platform", "WINDOWS")]
        [TestMethod]
        public void TestMethod1()
        {
            _browser.Navigate(@"http://google.com");
            HomePage start = new HomePage(_browser);
            start.
            SearchFrame.
            Search("sport5").
            SearchFrame.
            Search("walla");
        }
    }
}
