using OpenQA.Selenium;
using System.Threading;

namespace PageObjectPattern.Pages
{
    public class HomePage
    {
        IWebDriver _driver;
        public const string LOGGED_IN_USER_TEXT = "Logged in as";

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetLoggedInUserText()
        {
            Thread.Sleep(2000);
            return _driver.FindElement(By.XPath("//div[@id='content']/div[2]/div/h4")).Text;
        }
    }
}
