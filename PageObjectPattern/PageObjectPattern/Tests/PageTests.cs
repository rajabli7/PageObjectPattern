using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectPattern.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectPattern.Tests
{
    public class PageTests
    {
        IWebDriver _driver;

        [OneTimeSetUp]
        public void SetupWebDriver()
        {
            _driver = new ChromeDriver();
        }

        [Test, Order(1)]
        public void TestInvalidLogin()
        {
            LoginPage loginPage = new LoginPage(_driver);
            var invalidLoginError = loginPage.InvalidLogin();

            Assert.IsTrue(invalidLoginError.Contains(LoginPage.INVALID_LOGIN_ERROR));
        }

        [Test, Order(2)]
        public void TestLoginWithoutSessionLocation()
        {
            LoginPage loginPage = new LoginPage(_driver);
            var sessionLocationError = loginPage.LoginWithoutSessionLocation();

            Assert.IsTrue(sessionLocationError.Contains(LoginPage.SESSION_LOCATION_ERROR));
        }

        [Test, Order(3)]
        public void TestLogin()
        {
            LoginPage loginPage = new LoginPage(_driver);
            var loggedUserText = loginPage.Login().GetLoggedInUserText();

            Assert.IsTrue(loggedUserText.Contains(HomePage.LOGGED_IN_USER_TEXT));
        }

        [Test, Order(4)]
        public void TestPatientRegister()
        {
            RegisterPatientPage registerPatientPage = new RegisterPatientPage(_driver);
            string expected = "Some";

            string actual = registerPatientPage.RegisterPatient(expected).GetGivenName();

            Assert.AreEqual(expected, actual);
        }

        [Test, Order(5)]
        public void TestPatientDeleteWithoutReason()
        {
            PatientPage patientPage = new PatientPage(_driver);
            string reasonError = patientPage.DeletePatientWithoutReason();

            Assert.IsTrue(reasonError.Contains(PatientPage.REASON_ERROR));
        }

        [Test, Order(6)]
        public void TestPatientDelete()
        {
            PatientPage patientPage = new PatientPage(_driver);
            patientPage.DeletePatient();
            
            Assert.Pass();
        }

        [OneTimeTearDown]
        public void CloseWevDriver()
        {
            _driver.Close();
        }
    }
}
