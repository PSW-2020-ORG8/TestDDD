using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace E2ETests.WebAppPatientE2ETests.Pages
{
    public class PublishedFeedbacksPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:5000/index.html#/";
        private ReadOnlyCollection<IWebElement> publishedFeedbacks => driver.FindElements(By.XPath("//div[@class='feedback-info']"));       

        public PublishedFeedbacksPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(condition =>
            {
                try
                {
                    return publishedFeedbacks.Count > 0;
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

        public int PublishedFeedbackCount()
        {
            return publishedFeedbacks.Count;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
