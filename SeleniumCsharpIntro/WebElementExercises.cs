using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace SeleniumCsharpIntro
{
    [TestClass]
    public class WebElementExercises
    {
        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void WebElementExercise1Test()
        {
            string url = "http://book.theautomatedtester.co.uk/chapter1";
            this.driver.Url = url;

            // 1. Check the radio button
            var radioButton = this.driver.FindElement(By.Id("radiobutton"));
            Assert.IsFalse(radioButton.Selected);
            radioButton.Click();
            Assert.IsTrue(radioButton.Selected);

            // 2. Dropdown
            var defaultDropdownExpectedTet = "Selenium IDE";
            var wantedSelectedOption = "Selenium Grid";
            var dropdown = new SelectElement(this.driver.FindElement(By.TagName("select")));
            Assert.AreEqual(dropdown.SelectedOption.Text, defaultDropdownExpectedTet);
            dropdown.SelectByValue(wantedSelectedOption);
            Assert.AreEqual(dropdown.SelectedOption.Text, wantedSelectedOption);

            // 3. Navigate and check element availability
            var homePageLink = this.driver.FindElement(By.LinkText("Home Page"));
            homePageLink.Click();
            var chapter1Link = this.driver.FindElement(By.LinkText("Chapter1"));
            Assert.AreEqual(chapter1Link.Text, "Chapter1");

            // 4. Navigate Back
            this.driver.Navigate().Back();

            // 5. Check Checkbox besides Dropdown.
            var checkbox = this.driver.FindElement(By.Name("selected(1234)"));
            Assert.IsFalse(checkbox.Selected);
            checkbox.Click();
            Assert.IsTrue(checkbox.Selected);

            // 6. Assert Text on the Page
            var textParent = this.driver.FindElement(By.ClassName("leftdiv"));
            Assert.AreEqual(textParent.Text, "Assert that this text is on the page");
        }

        [TestMethod]
        public void WebElementExercise2Test()
        {
            string homePageUrl = "https://grup5web.firebaseapp.com/";
            string propertiesListUrl = "https://grup5web.firebaseapp.com/properties/properties.html?region=Navarra";

            // 1. Navigate first to homePageURL to let the app populate the local storage with properties
            this.driver.Url = homePageUrl;
            this.driver.Url = propertiesListUrl;

            // 2.Get Property Info
            var propertyCard = this.driver.FindElement(By.Id("card-1"));
            var price = propertyCard.FindElement(By.TagName("h2")).Text;
            var bedrooms = propertyCard.FindElement(By.Id("rooms-1")).Text.Split(' ')[0];
            var interestedPeople = propertyCard.FindElement(By.ClassName("likes")).Text.Split(' ')[0];
            Debug.WriteLine(price);
            Debug.WriteLine(bedrooms);
            Debug.WriteLine(interestedPeople);

            // 3. Go to details view and assert data consistency
            propertyCard.Click();
            var detailsPrice = this.driver.FindElement(By.Id("price")).Text.Replace(" ", string.Empty);
            var detailsBedrooms = this.driver.FindElement(By.Id("numberOfBedrooms")).Text.Split(' ')[0];

            var likesElement = this.driver.FindElement(By.Id("likes"));
            var detailsInterestedPeople = likesElement.Text;

            Assert.AreEqual(price, detailsPrice);
            Assert.AreEqual(bedrooms, detailsBedrooms);
            Assert.AreEqual(interestedPeople, detailsInterestedPeople);

            // 4. Send a Comment
            var commentsTextArea = this.driver.FindElement(By.Id("comments"));
            commentsTextArea.SendKeys("I am interested on this property!");
            commentsTextArea.Submit();
            Assert.AreEqual(Convert.ToInt32(detailsInterestedPeople) + 1, Convert.ToInt32(likesElement.Text));
            string numberOfLikes = likesElement.Text; // To avoid having a stale element when navigating out of the page!

            // 5. Navigate Back to Properties List
            this.driver.Navigate().Back();

            // 6. Check the new likes amount is correcet.
            propertyCard = this.driver.FindElement(By.Id("card-1"));
            interestedPeople = propertyCard.FindElement(By.ClassName("likes")).Text.Split(' ')[0];
            Assert.AreEqual(interestedPeople, numberOfLikes);
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.driver.Quit();
        }
    }
}
