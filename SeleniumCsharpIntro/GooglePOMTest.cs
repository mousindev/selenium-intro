using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumCsharpIntro.Pages;

namespace SeleniumCsharpIntro
{
    [TestClass]
    public class GooglePOMTest
    {
        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void FirstPOMTest()
        {
            this.driver.Url = "https://google.com";

            var page = new GooglePOM();
            PageFactory.InitElements(this.driver, page);

            page.searchBox.SendKeys("Selenium Page Object Model");

            this.driver.Quit();
        }
    }
}
