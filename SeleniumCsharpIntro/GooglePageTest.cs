using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCsharpIntro.Pages;

namespace SeleniumCsharpIntro
{
    [TestClass]
    public class GooglePageTest
    {
        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void GooglePageInitializationTest()
        {
            var google = new GooglePage(this.driver);
            Assert.AreEqual(this.driver.Title, google.InitTitle);
            Assert.AreEqual(google.GetSearchBoxValue(), string.Empty);
        }

        [TestMethod]
        public void FeelingLuckyInitializationTest()
        {
            var google = new GooglePage(this.driver);
            google.LuckyClick();
            Assert.AreEqual(this.driver.Title, google.LuckyInitTitle);
        }

        [TestMethod]
        public void SearchTest()
        {
            const string searchTerm = "Hello World";
            var google = new GooglePage(this.driver);
            google.Search(searchTerm);
            Assert.IsTrue(this.driver.Title.Contains(searchTerm));
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.driver.Quit();
        }
    }
}
