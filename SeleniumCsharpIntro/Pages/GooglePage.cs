using OpenQA.Selenium;

namespace SeleniumCsharpIntro.Pages
{
    public class GooglePage
    {
        const string url = "https://google.com";

        private IWebElement searchBox;
        private IWebElement searchButton;
        private IWebElement luckyButton;

        IWebDriver driver;

        public string InitTitle => "Google";

        public string LuckyInitTitle => "Google Doodles";

        public GooglePage(IWebDriver driver)
        {
            this.driver = driver;
            this.NavigateToPage();
            this.MapElements();
        }

        public void NavigateToPage()
        {
            this.driver.Url = url;
        }

        public void Search(string text)
        {
            this.searchBox.Clear();
            this.searchBox.SendKeys(text);
            this.searchBox.Submit();
        }

        public string GetSearchBoxValue()
        {
            return this.searchBox.GetAttribute("value");
        }

        public void LuckyClick()
        {
            luckyButton.Click();
        }

        private void MapElements()
        {
            searchBox = this.driver.FindElement(By.Name("q"));

            luckyButton = this.driver.FindElement(By.Name("btnI"));
        }
    }
}
