using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace E2ETests.WebAppPatientE2ETests.Pages
{
    public class PublishFeedbackPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:5000/index.html#/patientsFeedbacks";
        private IWebElement publishFeedbackButton => driver.FindElement(By.Id("publishFeedbackButton"));

        public PublishFeedbackPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool PublishFeedbackButtonDisplayed()
        {
            return publishFeedbackButton.Displayed;
        }

        public void ClickPublishFeedbackButton()
        {
            publishFeedbackButton.Click();
        }

        public void WaitForButtonClick()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(PublishedFeedbacksPage.URI));
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
