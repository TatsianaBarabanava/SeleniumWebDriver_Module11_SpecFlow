using System;
using System.Linq;

namespace SeleniumWebDriver.Utils
{
    public class RandomUtil
    {
        private RandomUtil() { }
        private static RandomUtil instance = null;

        public static RandomUtil Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomUtil();
                }
                return instance;
            }
        }

        public string getRandomText(int numberOfSymbols)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randomContent = new string(Enumerable.Range(1, numberOfSymbols).Select(_ => chars[random.Next(chars.Length)]).ToArray());

            return randomContent;
        }
    }
}
