using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumCsharpIntro.Pages
{
    public class GooglePOM
    {
        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement searchBox;

        [FindsBy(How = How.Name, Using = "btnI")]
        public IWebElement luckyButton;
    }
}
