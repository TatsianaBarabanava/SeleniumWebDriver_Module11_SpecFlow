using SeleniumWebDriver.BusinessObjects.Emails;

namespace SeleniumWebDriver.BusinessObjects
{
    public class CommonEmailInstance : BaseEmailInstance
    {
        public CommonEmailInstance()
        {
        }

        public CommonEmailInstance(string sender, string email, string subject, string content)
        {
            this._sender = sender;
            this._email = email;
            this._subject = subject;
            this._content = content;
        }

        public override BaseEmailInstance getInstanceWithRandomSubjectAndContent(string sender, string email)
        {
            string randomSubject = _randomUtil.getRandomText(5);
            string randomContent = _randomUtil.getRandomText(10);

            return new CommonEmailInstance(sender, email, randomSubject, randomContent);
        }

        public override BaseEmailInstance getInstanceWithRandomSubjectAndContent()
        {
            string randomEmail = _randomUtil.getRandomText(5)+"@mail.ru";
            string randomSender = _randomUtil.getRandomText(5)+" " + _randomUtil.getRandomText(8);

            return  getInstanceWithRandomSubjectAndContent(randomSender, randomEmail);
        }
    }
}
