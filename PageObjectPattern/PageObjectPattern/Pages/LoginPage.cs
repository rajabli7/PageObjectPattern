using OpenQA.Selenium;
using System.Threading;

namespace PageObjectPattern.Pages
{
    public class LoginPage
    {
        IWebDriver _driver;
        public const string INVALID_LOGIN_ERROR = "Invalid username/password. Please try again.";
        public const string SESSION_LOCATION_ERROR = "You must choose a location!";

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl("https://demo.openmrs.org/openmrs/login.htm");
        }

        public string InvalidLogin()
        {
            _driver.FindElement(By.XPath("//input[@id='username']")).SendKeys("admin");
            _driver.FindElement(By.XPath("//input[@id='password']")).SendKeys("Admin1223");
            _driver.FindElement(By.XPath("//li[@id='Laboratory']")).Click();
            _driver.FindElement(By.XPath("//input[@id='loginButton']")).Click();

            Thread.Sleep(2000);
            return _driver.FindElement(By.XPath("//div[@id='error-message']")).Text;
        }

        public string LoginWithoutSessionLocation()
        {
            _driver.FindElement(By.XPath("//input[@id='username']")).SendKeys("admin");
            _driver.FindElement(By.XPath("//input[@id='password']")).SendKeys("Admin123");
            _driver.FindElement(By.XPath("//input[@id='loginButton']")).Click();

            Thread.Sleep(1000);
            return _driver.FindElement(By.XPath("//span[@id='sessionLocationError']")).Text;
        }

        public HomePage Login()
        {
            _driver.FindElement(By.XPath("//input[@id='username']")).SendKeys("admin");
            _driver.FindElement(By.XPath("//input[@id='password']")).SendKeys("Admin123");
            _driver.FindElement(By.XPath("//li[@id='Laboratory']")).Click();
            _driver.FindElement(By.XPath("//input[@id='loginButton']")).Click();

            return new HomePage(_driver);
        }
    }
}

