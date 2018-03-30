using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCsharpIntro
{
    [TestClass]
    public class DriverNavigationExercises
    {
        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void DriverNavigationExerciseTest()
        {
            string googleUrl = "https://google.com";
            this.driver.Navigate().GoToUrl(googleUrl);

            this.driver.FindElement(By.Name("btnI")).Click();
            string luckyTitle = this.driver.Title;

            this.driver.Navigate().Back();
            Assert.AreNotEqual(this.driver.Title, luckyTitle);
            Assert.AreNotEqual(this.driver.Url, googleUrl);
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.driver.Quit();
        }
    }
}
