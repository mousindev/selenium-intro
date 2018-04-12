using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCsharpIntro.Pages;

namespace SeleniumCsharpIntro
{
    [TestClass]
    public class LoginTest
    {
        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void LoginSuccessTest()
        {
            this.driver.Url = "https://grup5web.firebaseapp.com/login/login.html";

            var page = new Login(this.driver);

            page.SetCredentials("LordDarkHelmet", "12345");
            page.LoginIntoApp();
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.driver.Quit();
        }
    }
}
