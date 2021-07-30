using OpenQA.Selenium;

namespace SeleniumWebDriver
{
    public class DraftPage : BaseMailPage
    {
        public static readonly string url = "https://mail.yandex.by/u2709/?uid=1437990165#draft";
        private static readonly By draftMail = By.XPath("//span[text()='Создать шаблон']");
        public BaseElement deleteButton = new BaseElement(By.XPath("//span[contains(@class,'js-toolbar-item-title-delete')]"));

        public DraftPage() : base(draftMail, "Draft Mail")
        {
        }
    }
}