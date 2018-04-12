using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCsharpIntro.Pages;
using System.Diagnostics;

namespace SeleniumCsharpIntro
{
    [TestClass]
    public class PropertyDetailsTest
    {
        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
            this.driver.Url = "https://grup5web.firebaseapp.com";
        }

        [TestMethod]
        public void NavigateThroughPropertiesTest()
        {
            this.driver.Url = "https://grup5web.firebaseapp.com/property-details/property-details.html?id=9";

            var page = new PropertyDetailsPage(this.driver);

            int initialPropertyId = page.GetPropertyId();
            Debug.WriteLine("Initial Property " + initialPropertyId);

            // Navigate to the first Property
            while (page.CanGoToPreviousProperty())
            {
                page.GoToPreviousProperty();
            }

            int firstPropertyId = page.GetPropertyId();
            Debug.WriteLine("First Property " + firstPropertyId);
            Assert.AreNotEqual(initialPropertyId, firstPropertyId);

            // Navigate to last property (the one we were in the beginning)
            while (page.CanGoToNextProperty())
            {
                page.GoToNextProperty();
            }

            int lastPropertyId = page.GetPropertyId();
            Debug.WriteLine("Last Property " + lastPropertyId);
            Assert.AreEqual(initialPropertyId, lastPropertyId);
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.driver.Quit();
        }
    }
}
