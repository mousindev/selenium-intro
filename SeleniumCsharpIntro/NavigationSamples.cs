using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCsharpIntro
{
    [TestClass]
    public class NavigationSamples
    {
        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void NavigateToNavigateBackNavigateForwardRefreshTest()
        {
            this.driver.Navigate().GoToUrl("https://google.com");
            Assert.AreEqual(this.driver.Title, "Google");

            this.driver.Navigate().GoToUrl("https://bing.com");
            Assert.AreEqual(this.driver.Title, "Bing");

            this.driver.Navigate().Back();
            Assert.AreEqual(this.driver.Title, "Google");

            this.driver.Navigate().Forward();
            Assert.AreEqual(this.driver.Title, "Bing");

            this.driver.Navigate().Refresh();
            Assert.AreEqual(this.driver.Title, "Bing");
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.driver.Quit();
        }
    }
}
