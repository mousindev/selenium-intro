using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCsharpIntro
{
    [TestClass]
    public class FirstTest
    {
        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void MyFirstTest()
        {
            //this.driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("http://google.com");
            //this.driver.Quit();
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.driver.Quit();
        }
    }
}
