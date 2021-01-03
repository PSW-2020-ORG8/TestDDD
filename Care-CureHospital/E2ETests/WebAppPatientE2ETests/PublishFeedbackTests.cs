using E2ETests.WebAppPatientE2ETests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace E2ETests.WebAppPatientE2ETests
{
    public class PublishFeedbackTests : IDisposable
    {
        private readonly IWebDriver driver;
        private PublishFeedbackPage publishFeedbackPage;
        private PublishedFeedbacksPage publishedFeedbacksPage;
        private int publishedFeedbacksCount = 0;

        public PublishFeedbackTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");     
            options.AddArguments("disable-infobars");         
            options.AddArguments("--disable-extensions");    
            options.AddArguments("--disable-gpu");            
            options.AddArguments("--disable-dev-shm-usage");  
            options.AddArguments("--no-sandbox");              
            options.AddArguments("--disable-notifications");  

            driver = new ChromeDriver(options);

            publishedFeedbacksPage = new PublishedFeedbacksPage(driver);
            publishedFeedbacksPage.Navigate();
            publishedFeedbacksPage.EnsurePageIsDisplayed();
            publishedFeedbacksCount = publishedFeedbacksPage.PublishedFeedbackCount();
            Assert.Equal(driver.Url, PublishedFeedbacksPage.URI);

            publishFeedbackPage = new PublishFeedbackPage(driver);
            publishFeedbackPage.Navigate();
            Assert.Equal(driver.Url, PublishFeedbackPage.URI);
            Assert.True(publishFeedbackPage.PublishFeedbackButtonDisplayed());           
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestSuccessfulPublishFeedback()
        {
            publishFeedbackPage.ClickPublishFeedbackButton();
            //publishFeedbackPage.WaitForButtonClick();

            PublishedFeedbacksPage newPublishedFeedbacksPage = new PublishedFeedbacksPage(driver);
            newPublishedFeedbacksPage.Navigate();
            newPublishedFeedbacksPage.EnsurePageIsDisplayed();

            Assert.Equal(publishedFeedbacksCount + 1, newPublishedFeedbacksPage.PublishedFeedbackCount());                                
        }
    }
}
