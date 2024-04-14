using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SyFramework.Test
{
    public class TestWebBase
    {
        public IWebDriver Driver { get; set; }

        public TestWebBase() => InitializeWebDriver();

        private void InitializeWebDriver()
        {
            Driver = new ChromeDriver();
        }

        public void NavigateToUrl()
        {
            Driver.Navigate().GoToUrl("https://symphony.is/");
            Driver.Manage().Window.Maximize();
            HandleCookiesPopup();
        }

        public void CloseWebBrowser()
        {
            Driver.Quit();
        }

        public void VerifyCorrectPageUrl(string url)
        {
            Assert.AreEqual(url, Driver.Url);
        }

        private void HandleCookiesPopup()
        {
            IWebElement acceptCookiesButton = Driver.FindElement(By.CssSelector("button.cookiesBanner--btn.cookiesBanner--btn_purple"));
            acceptCookiesButton.Click();

        }
    }
}

