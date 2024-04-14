using OpenQA.Selenium;

namespace SyFramework.Page
{
    public class HomePage
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Locators

        public IWebElement AboutUs => driver.FindElement(By.XPath("//span[normalize-space()='About Us']"));
        public IWebElement Company => driver.FindElement(By.XPath("//*[@href='/about-us/company']"));
        public IWebElement Careers => driver.FindElement(By.XPath("//span[normalize-space()='Careers']"));

        #endregion

        #region Methods

        public void CickOnCompany()
        {
            AboutUs.Click();
            Company.Click();
        }

        public void ClickOnCareers()
        {
            Careers.Click();
        }

        #endregion

    }
}
