using NUnit.Framework;
using SeleniumWebDriver.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumWebDriver.Steps
{
    [Binding]
    public sealed class Steps : BaseSteps
    {
        #region Given Steps

        [Given(@"I create an Email")]
        public void CreateAnEmail()
        {
           new MailPage().ComposeEmailWithRandomContent(gmailEmailInstance);
        }
        [Given(@"I create an Email for Yandex")]
        public void CreateAnEmailForYandex()
        {
            new MailPage().ComposeEmailWithRandomContent(yandexEmailInstance);
        }

        #endregion

        #region When Steps

        [When(@"I click on LoginButton")]
        public void ClickOnLoginButton()
        {
            homePage.ClickOnLoginButton();
        }

        [When(@"I login with '(.*)' and '(.*)' credentials")]
        public void LoginWithCredentials(string login, string password)
        {
            User user = new User(login, password);
            new YandexLoginPage().Login(user);
        }

        [When(@"I escape the created email")]
        public void EscapeTheCreatedEmail()
        {
            Browser.PressEscape();
        }

        [When(@"I go to Draft folder")]
        public void GoToDraftFolder()
        {
            new BaseMailPage().ClickOnDraftLink();
        }

        [When(@"I select created email")]
        public void SelectCreatedEmail()
        {
            new DraftPage().SelectEmailByNumber(0, gmailEmailInstance.Email);
        }

        [When(@"I delete the email from Draft folder")]
        public void DeleteTheEmailFromDraftFolder()
        {
            new DraftPage().deleteButton.Click();
        }

        [When(@"I go to Delete folder")]
        public void GoToDeleteFolder()
        {
            new DraftPage().ClickOnDeleteFolder();
        }

        [When(@"I click on recepientField")]
        public void ClickOnRecepientField()
        {
            new BaseMailPage().ClickOnRecepientField(yandexEmailInstance.Email);
        }

        [When(@"I click on recepientField for Yandex")]
        public void ClickOnRecepientFieldForYandex()
        {
            new BaseMailPage().ClickOnRecepientField(gmailEmailInstance.Email);
        }

        [When(@"I click Send button")]
        public void ClickSendButton()
        {
            new DraftPage().ClickOnSendButtonWithActions();
        }

        [When(@"I escape the notification message")]
        public void EscapeTheNotificationMessage()
        {
            Browser.PressEscape();
        }

        [When(@"I go to Inbox folder")]
        public void GoToInboxFolder()
        {
            new DraftPage().ClickOnInboxFolder();
        }

        [When(@"I refresh the Page")]
        public void RefreshThePage()
        {
            Browser.RefreshPage();
        }

        [When(@"I count the number of existing emails in Draft folder")]
        public int CountTheNumberOfExistingEmailsInDraftFolder()
        {
            actualNumberOfDrafts = new DraftPage().CountEmails(gmailEmailInstance.Email);

            return actualNumberOfDrafts;
        }

        [When(@"I count the number of emails in Draft folder one more time")]
        public bool CountTheNumberOfEmailsInDraftFolderOneMoreTime()
        {
            expectedNumberOfDrafts = new DraftPage().CountEmails(gmailEmailInstance.Email) == (actualNumberOfDrafts - 1);

            return expectedNumberOfDrafts;
        }

        [When(@"I go to Send folder")]
        public void GoToSendFolder()
        {
            new DraftPage().ClickOnSendFolder();
        }

        #endregion

        #region Then Steps

        [Then(@"I get the compose link text")]
        public string GetTheComposeLinkText()
        {
            actualExpression = homePage.GetTextFromComposeLink();

            return actualExpression;
        }

        [Then(@"The compose link text presents on the Page")]
        public void ComposeLinkTextPresentsOnThePage()
        {
            Assert.AreEqual(composeLinkText, actualExpression, "You are on the wrong page");
        }

        [Then(@"The send email should disappear from Draft folder")]
        public void SendEmailShouldDisappearFromDraftFolder()
        {
            Assert.IsTrue(expectedNumberOfDrafts, "The Number Of Letters In Mail Box is different from Expected Value");
        }

        [Then(@"The send email should appear in Send folder")]
        public void SendEmailShouldAppearInSendFolder()
        {
            SendPage sendPage = new SendPage();
            var actualSender = sendPage.GetTextFromRecepientField(gmailEmailInstance.Email);
            var actualSubject = sendPage.GetTextFromMailTopicField();
            var actualContent = sendPage.GetTextFromContentField();
            Assert.AreEqual(gmailEmailInstance.Email, actualSender, "Sender field has an invalid value");
            Assert.AreEqual(gmailEmailInstance.Subject, actualSubject, "Email Subject field has an invalid value");
            Assert.AreEqual(sendPage.GetTextFromContentField(), actualContent, "Content field has an invalid value");
        }

        [Then(@"The send email should appear in Inbox folder")]
        public void SendEmailShouldAppearInInboxFolder()
        {
            ReceivePage receivePage = new ReceivePage();
            var actualSender = receivePage.GetTextFromRecepientField(yandexEmailInstance.Email);
            var actualSubject = receivePage.GetTextFromMailTopicField();
            var actualContent = receivePage.GetTextFromContentField();
            Assert.AreEqual(yandexEmailInstance.Sender, actualSender, "Sender field has an invalid value");
            Assert.IsTrue(actualSubject.Contains(yandexEmailInstance.Subject), "Email Subject field has an invalid value");
            Assert.AreEqual(receivePage.GetTextFromContentField(), actualContent, "Content field has an invalid value");
        }

        [Then(@"The deleted email should appear in Delete folder")]
        public void DeletedEmailShouldAppearInDeleteFolder()
        {
            DeletePage deletePage = new DeletePage();
            var actualSender = deletePage.GetTextFromRecepientField(yandexEmailInstance.Email);
            var actualSubject = deletePage.GetTextFromMailTopicField();
            var actualContent = deletePage.GetTextFromContentField();
            Assert.AreEqual(gmailEmailInstance.Sender, actualSender, "Sender field has an invalid value");
            Assert.AreEqual(gmailEmailInstance.Subject, actualSubject, "Email Subject field has an invalid value");
            Assert.AreEqual(deletePage.GetTextFromContentField(), actualContent, "Content field has an invalid value");
        }

        [Then(@"The created email should appear in Draft folder")]
        public void CreatedEmailShouldAppearInDraftFolder()
        {
            DraftPage draftPage = new DraftPage();
            var actualSender = draftPage.GetTextFromRecepientField(gmailEmailInstance.Email);
            var actualSubject = draftPage.GetTextFromMailTopicField();
            var actualContent = draftPage.GetTextFromContentField();
            Assert.AreEqual(gmailEmailInstance.Email, actualSender, "Sender field has an invalid value");
            Assert.AreEqual(gmailEmailInstance.Subject, actualSubject, "Email Subject field has an invalid value");
            Assert.AreEqual(draftPage.GetTextFromContentField(), actualContent, "Content field has an invalid value");
        }

        #endregion
    }
}
