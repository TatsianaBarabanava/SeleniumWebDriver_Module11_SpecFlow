using System.Configuration;

namespace SeleniumWebDriver.BusinessObjects
{
    public class User
    {
        public readonly string _login;
        public readonly string _password;

        public string[] DataUser { get; private set; }

        public User (string login, string password)
        {
            this._login = login;
            this._password = password;
            DataUser = new[] { this._login, this._password };
        }

        public static User GetDefaultUser()
        {
            return new User(ConfigurationManager.AppSettings.Get("login"), ConfigurationManager.AppSettings.Get("password"));
        }
    }
}
