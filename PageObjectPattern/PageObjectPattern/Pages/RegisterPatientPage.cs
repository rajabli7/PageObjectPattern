using OpenQA.Selenium;
using System.Threading;

namespace PageObjectPattern.Pages
{
    public class RegisterPatientPage
    {
        IWebDriver _driver;
        
        public RegisterPatientPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl("https://demo.openmrs.org/openmrs/registrationapp/registerPatient.page?appId=referenceapplication.registrationapp.registerPatient");
        }

        public PatientPage RegisterPatient(string givenName)
        {
            Thread.Sleep(1000);

            // Name 
            _driver.FindElement(By.XPath("//input[@name='givenName']")).SendKeys(givenName);
            _driver.FindElement(By.XPath("//input[@name='middleName']")).SendKeys("Test");
            _driver.FindElement(By.XPath("//input[@name='familyName']")).SendKeys("user");

            _driver.FindElement(By.XPath("//button[@id='next-button']")).Click();

            // Gender
            _driver.FindElement(By.XPath("//select[@id='gender-field']/option[1]")).Click();

            _driver.FindElement(By.XPath("//button[@id='next-button']")).Click();

            // Birthday
            _driver.FindElement(By.XPath("//input[@id='birthdateDay-field']")).SendKeys("17");
            _driver.FindElement(By.XPath("//select[@id='birthdateMonth-field']/option[3]")).Click();
            _driver.FindElement(By.XPath("//input[@id='birthdateYear-field']")).SendKeys("2004");

            _driver.FindElement(By.XPath("//button[@id='next-button']")).Click();

            // Address
            _driver.FindElement(By.XPath("//input[@id='address1']")).SendKeys("Main address");

            _driver.FindElement(By.XPath("//button[@id='next-button']")).Click();
            _driver.FindElement(By.XPath("//button[@id='next-button']")).Click();
            _driver.FindElement(By.XPath("//button[@id='next-button']")).Click();

            _driver.FindElement(By.XPath("//input[@id='submit']")).Click();

            return new PatientPage(_driver);
        }
    }
}
