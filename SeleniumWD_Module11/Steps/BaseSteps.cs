using TechTalk.SpecFlow;
using SeleniumWebDriver.BusinessObjects;
using OpenQA.Selenium;

namespace SeleniumWebDriver.Steps
{
    public abstract class BaseSteps
    {
        #region Variables

        private string baseUrl;
        protected Browser Browser;
        protected YandexHomePage homePage;
        public static string composeLinkText = "Написать письмо";
        public static User user = User.GetDefaultUser();
        public bool expectedNumberOfDrafts;
        public int actualNumberOfDrafts;
        public static string actualExpression;
        public static CommonEmailInstance gmailEmailInstance = (CommonEmailInstance)new GmailEmailInstance().getInstanceWithRandomSubjectAndContent();
        public static CommonEmailInstance yandexEmailInstance = (CommonEmailInstance)new YandexEmailInstance().getInstanceWithRandomSubjectAndContent();

        #endregion

        #region Preconditions

        [BeforeScenario("NotLoggedUser")]
        public void NotLoggedUserBeforeScenario()
        {
            this.baseUrl = YandexHomePage.url;
            Browser = Browser.Instance;
            Browser.NavigateTo(this.baseUrl);
            Browser.WindowMaximize();
            homePage = new YandexHomePage();
        }

        [BeforeScenario("LoggedUser")]
        public void LoggedUserBeforeScenario()
        {
            this.baseUrl = YandexHomePage.url;
            Browser = Browser.Instance;
            Browser.NavigateTo(this.baseUrl);
            Browser.WindowMaximize();
            new YandexHomePage().ClickOnLoginButton().Login(user).WaitForComposeLinkIsVisible();
            homePage = new YandexHomePage();
            homePage.ClickOnComposeLink();
            homePage.SwitchToMailPageWindow();
        }

        #endregion

        #region Postconditions

        [AfterScenario]
        public void AfterTestRun()
        {
            Browser.Quit();
        }

        #endregion

    }
}
