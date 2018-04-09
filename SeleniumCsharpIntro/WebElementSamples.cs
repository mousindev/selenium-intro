using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCsharpIntro
{
    [TestClass]
    public class WebElementSamples
    {
        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void WebElementTest()
        {
            IWebElement queryInput;
            string url = "https://google.com";
            this.driver.Url = url;

            // BASIC OF FINDING ELEMENT
            // Try the two below, one by one
            queryInput = this.driver.FindElement(By.Id("lst-ib"));
            // queryInput = this.driver.FindElement(By.Name("q"));

            // CHECKING SOME IWEBELEMENT PROPERTIES
            Assert.IsTrue(queryInput.Displayed);
            Assert.IsTrue(queryInput.Enabled);
            Assert.AreEqual(queryInput.TagName, "input");

            Debug.WriteLine("Query Input size is {0} height and {1} width", queryInput.Size.Height, queryInput.Size.Width);
            Debug.WriteLine("Query Input location is {0} horizontal {1} vertical", queryInput.Location.X, queryInput.Location.Y);

            // USING SOME IWEBELEMENT METHODS
            var queryText = "Automation wth Selenium and C#";
            queryInput.SendKeys(queryText);
            Assert.AreEqual(queryInput.GetAttribute("value"), queryText);

            queryInput.Clear();
            Assert.AreEqual(queryInput.GetAttribute("value"), "");

            queryInput.SendKeys(queryText);
            queryInput.Submit();

            Assert.AreNotEqual(this.driver.Title, "Google");

        }

        [TestMethod]
        public void SelectClassTest()
        {
            SelectElement filter;
            // Sample web done by my wife with some University team mates :)
            string url = "https://grup5web.firebaseapp.com/properties/properties.html?region=Navarra";
            this.driver.Url = url;

            // CHECKING SOME SELECTELEMENT PROPERTIES 
            filter = new SelectElement(this.driver.FindElement(By.Id("filter")));
            Assert.IsFalse(filter.IsMultiple);
            Debug.WriteLine("These are the available options:");
            foreach (var option in filter.Options)
            {
                Debug.WriteLine(option.Text);
            }
            Debug.WriteLine("DEFAULTED OPTION: " + filter.SelectedOption.Text);

            int lastOptionIndex = filter.Options.Count - 1;
            string lastOptionText = filter.Options[lastOptionIndex].Text;
            filter.SelectByIndex(lastOptionIndex);

            Assert.AreEqual(filter.SelectedOption.Text, lastOptionText);
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.driver.Quit();
        }
    }
}
