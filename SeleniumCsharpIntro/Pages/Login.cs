using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumCsharpIntro.Pages
{
    public class Login
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement userNameInput;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordInput;

        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void SetCredentials(string username, string password)
        {
            this.userNameInput.SendKeys(username);
            this.passwordInput.SendKeys(password);
        }

        public void LoginIntoApp()
        {
            this.userNameInput.Submit();
        }
    }
}
