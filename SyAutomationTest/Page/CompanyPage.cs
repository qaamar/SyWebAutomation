using OpenQA.Selenium;
using NUnit.Framework;

namespace SyFramework.Page
{
    public class CompanyPage
    {
        IWebDriver driver;

        public CompanyPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Locators

        private IList<IWebElement> CompanyInfo => driver.FindElements(By.XPath("//ul[@class='pageMetaDetails--list']/li"));

        #endregion

        #region Methods

        public void VerifyCompanyInformation()
        {
            Dictionary<string, string> expectedValues = new Dictionary<string, string>
            {
                { "HQ", "San Francisco" },
                { "Founded", "2007" },
                { "Size", "650+" },
                { "Consulting Locations", "Amsterdam, Berlin, Geneva, London, Los Angeles, Madrid, New York, Portland, Zürich" },
                { "Engineering Hubs", "Banja Luka, Belgrade, Nis, Novi Sad, Santo Domingo, Sarajevo, Skopje" },
                { "Clients", "300+" },
                { "Certifications", "AWS Certified Partner, ISO 27001:2013, ISO 9001:2015" }
            };

            foreach (var el in expectedValues)
            {
                IWebElement lista = CompanyInfo.FirstOrDefault(e => e.FindElement(By.TagName("strong")).Text == el.Key);

                if (lista != null)
                {
                    var spanElements = lista.FindElements(By.TagName("span"));
                    string actualValue = string.Join(", ", spanElements.Select(span => span.Text));

                    Assert.AreEqual(el.Value, actualValue);
                }
                else
                {
                    throw new Exception($"List item with label '{el.Key}' not found.");
                }
            }
        }

        #endregion
    }
}

