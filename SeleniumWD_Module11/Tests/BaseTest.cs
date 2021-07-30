using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumWebDriver.BusinessObjects;

namespace SeleniumWebDriver
{
    [TestFixture]
    public abstract class BaseTest : Browser
    {
        protected IWebDriver driver;
        protected string baseUrl;
        protected string composeLinkText = "Написать письмо";
        protected readonly User user = User.GetDefaultUser();
        protected readonly CommonEmailInstance yandexEmailInstance = (CommonEmailInstance) new YandexEmailInstance().getInstanceWithRandomSubjectAndContent();
        protected readonly CommonEmailInstance gmailEmailInstance = (CommonEmailInstance) new GmailEmailInstance().getInstanceWithRandomSubjectAndContent();

        [SetUp]
        public void TestSetup()
        {
            this.driver = GetDriver();
            this.baseUrl = YandexHomePage.url;

            NavigateTo(this.baseUrl);
            WindowMaximize();
            
            var homePage = new YandexHomePage();
            homePage.ClickOnLoginButton().Login(user).WaitForComposeLinkIsVisible();
        }

        [TearDown]
          public void CleanUp()
         {
             Quit();
         }
    }
}