using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace E2ETests.WebAppPatientE2ETests.Pages
{
    class PatientAppointmentsPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:5000/index.html#/patientAppointments";
        private IWebElement cancelAppointmentButton;
        private ReadOnlyCollection<IWebElement> patientAppointments => driver.FindElements(By.XPath("//div[@class='appointments-info']"));

        public PatientAppointmentsPage(IWebDriver driver)
        {
            this.driver = driver;
            try
            {
                cancelAppointmentButton = driver.FindElement(By.Id("cancelAppointmentButton"));
            }
            catch (NoSuchElementException)
            {
                cancelAppointmentButton = null;
            }
        }

        public bool CancelAppointmentButtonDisplayed()
        {
            return cancelAppointmentButton.Displayed;
        }

        public int PatientAppointmentsCount()
        {
            return patientAppointments.Count;
        }

        public void ClickCancelAppointmentButton()
        {
            cancelAppointmentButton.Click();
        }

        public bool IsCancelAppointmentButtonNull()
        {
            return cancelAppointmentButton == null;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(condition =>
            {
                try
                {
                    return patientAppointments.Count > 0;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void WaitForButtonClick()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(PatientAppointmentsPage.URI));
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
