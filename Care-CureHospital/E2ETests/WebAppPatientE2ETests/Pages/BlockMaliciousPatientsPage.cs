using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace E2ETests.WebAppPatientE2ETests.Pages
{
    public class BlockMaliciousPatientsPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:5000/index.html#/blockMaliciousPatients";
        private IWebElement blockMaliciousPatientButton => driver.FindElement(By.ClassName("block-malicious-patient-btn"));
        private ReadOnlyCollection<IWebElement> patientsForBlocking => driver.FindElements(By.ClassName("patient-for-blocking"));


        public BlockMaliciousPatientsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool BlockMaliciousPatientButtonDisplayed()
        {
            return blockMaliciousPatientButton.Displayed;
        }

        public void ClickBlockMaliciousPatientButton()
        {
            blockMaliciousPatientButton.Click();
        }

        public int PatientsForBlockingCount()
        {
            return patientsForBlocking.Count;
        }

        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public void ResolveAlertDialog()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
