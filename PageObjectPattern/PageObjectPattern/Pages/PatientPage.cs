using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PageObjectPattern.Pages
{
    public class PatientPage
    {
        IWebDriver _driver;
        public const string REASON_ERROR = "Reason cannot be empty";

        public PatientPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetGivenName()
        {
            Thread.Sleep(2000);
            return _driver
                .FindElement(By.XPath("//span[contains(@class, 'PersonName-givenName')]")).Text;
        }

        public string DeletePatientWithoutReason()
        {
            _driver.FindElement(By.XPath("//a[@id='org.openmrs.module.coreapps.deletePatient']")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//div[@id='delete-patient-creation-dialog'][1]/div[@class='dialog-content'][1]/button[@class='confirm right'][1]")).Click();

            return _driver.FindElement(By.XPath("//div[@id='delete-patient-creation-dialog'][1]/div[@class='dialog-content']/h6[@id='delete-reason-empty']")).Text;
        }

        public void DeletePatient()
        {
            _driver.FindElement(By.XPath("//input[@id='delete-reason']")).SendKeys("Some reason");
            _driver.FindElement(By.XPath("//div[@id='delete-patient-creation-dialog'][1]/div[@class='dialog-content'][1]/button[@class='confirm right'][1]")).Click();
        }
    }
}
