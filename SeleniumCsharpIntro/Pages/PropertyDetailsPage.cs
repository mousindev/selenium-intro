using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace SeleniumCsharpIntro.Pages
{
    public class PropertyDetailsPage
    {
        [FindsBy(How = How.Id, Using = "previousProperty")]
        private IWebElement previousPropertyLink;

        [FindsBy(How = How.Id, Using = "nextProperty")]
        private IWebElement nextPropertyLink;

        [FindsBy(How = How.Id, Using = "propertyId")]
        private IWebElement propertyIdInput;

        [FindsBy(How = How.Id, Using = "main-image")]
        private IWebElement propertyImage;

        [FindsBy(How = How.Id, Using = "miniature-images-section")]
        private IWebElement propertyMiniaturesContainer;

        [FindsBy(How = How.Id, Using = "price")]
        private IWebElement priceLabel;

        [FindsBy(How = How.Id, Using = "likes")]
        private IWebElement likesLabel;

        [FindsBy(How = How.Id, Using = "year")]
        private IWebElement constructionYearLabel;

        [FindsBy(How = How.Id, Using = "numberOfBedrooms")]
        private IWebElement bedroomsLabel;

        [FindsBy(How = How.Id, Using = "address")]
        private IWebElement addressLabel;

        [FindsBy(How = How.Id, Using = "description")]
        private IWebElement descriptionLabel;

        [FindsBy(How = How.Id, Using = "comments")]
        private IWebElement commentsInput;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement sendButton;

        public PropertyDetailsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public int GetPropertyId()
        {
            return Convert.ToInt32(propertyIdInput.GetAttribute("value"));
        }

        public bool CanGoToPreviousProperty()
        {
            return previousPropertyLink.Displayed;
        }

        public void GoToPreviousProperty()
        {
            previousPropertyLink.Click();
        }

        public bool CanGoToNextProperty()
        {
            return nextPropertyLink.Displayed;
        }

        public void GoToNextProperty()
        {
            nextPropertyLink.Click();
        }
    }
}
