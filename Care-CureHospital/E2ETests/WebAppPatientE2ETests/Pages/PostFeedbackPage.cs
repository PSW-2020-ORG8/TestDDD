using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace E2ETests.WebAppPatientE2ETests.Pages
{
    class PostFeedbackPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:5000/index.html#/postFeedback";
        private IWebElement textField => driver.FindElement(By.Id("feedbackID"));
        private IWebElement anonyimusCheckbox => driver.FindElement(By.Id("isAnonymous"));
        private IWebElement publishedCheckbox => driver.FindElement(By.Id("isForPublishing"));
        private IWebElement submitButton => driver.FindElement(By.Id("SendFeedbackButton"));
        private IWebElement errorMessage => driver.FindElement(By.Id("FeedbackErrorMessage"));
        public string Title => driver.Title;
        public const string ValidMessage = "Utisak je uspešno ostavljen";
        public const string InvalidMessage = "Morate popuniti polje kako biste ostavili utisak!";

        public PostFeedbackPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool TextElementDisplayed()
        {
            return textField.Displayed;
        }

        public bool AnonyimusCheckBoxDisplayed()
        {
            return anonyimusCheckbox.Displayed;
        }

        public bool PublishedCheckboxDisplayed()
        {
            return publishedCheckbox.Displayed;
        }

        public bool SubmitButtonDisplayed()
        {
            return submitButton.Displayed;
        }

        public void SubmitForm()
        {
            submitButton.Click();
        }

        public void InsertText(string text)
        {
            textField.SendKeys(text);
        }

        public void EnablePublishedCheckbox(string status)
        {
            publishedCheckbox.SendKeys(status);
        }

        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public void WaitForButton()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(condition =>
            {
                try
                {
                    return (SubmitButtonDisplayed() == true);
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

        public string GetDialogMessage()
        {
            return driver.SwitchTo().Alert().Text;
        }

        public bool ErrorMessageDisplayed()
        {
            return errorMessage.Displayed;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
