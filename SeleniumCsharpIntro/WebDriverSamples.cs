using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace SeleniumCsharpIntro
{
    [TestClass]
    public class WebDriverSamples
    {
        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void PageSourceTest()
        {
            this.driver.Url = "https://google.com";
            Debug.WriteLine(this.driver.PageSource); // Get it on the Output link in the bottom part of the test explorer when this test is selected.
        }

        [TestMethod]
        public void TitleTest()
        {
            this.driver.Url = "https://google.com";
            Assert.AreEqual(this.driver.Title, "Bing"); // Will Fail!
        }

        [TestMethod]
        public void FindElementTest()
        {
            this.driver.Url = "https://google.com";
            this.driver.FindElement(By.Name("btnI")).Click();
            Assert.AreEqual(this.driver.Title, "Google Doodles");
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.driver.Quit();
        }
    }
}
