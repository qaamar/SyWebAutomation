using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;

namespace SyFramework.Page;

public class CareersPage
{
    IWebDriver driver;

    public CareersPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    #region Locators

    public IWebElement CurrentOpeningsLabel => driver.FindElement(By.Id("current-openings"));
    public IList<IWebElement> ListOfCurrentOpenings => driver.FindElements(By.XPath("//*[contains(@class, 'currentOpenings--jobs')]/li"));

    #endregion

    #region Methods

    public void NavigateToCurrentOpenings()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView();", CurrentOpeningsLabel);
    }

    public void VerifyNumberOfCurrentOpenings(int numberOfOpenings)
    {
        WaitUntilElementIsVisible(By.XPath("//*[contains(@class, 'currentOpenings--jobs')]/li"), TimeSpan.FromSeconds(10));
        int actualNumberOfOpenings = ListOfCurrentOpenings.Count();
        int expectedNumberOfOpenings = numberOfOpenings;
        Assert.AreEqual(expectedNumberOfOpenings, actualNumberOfOpenings);
    }

    public void CreateTxtWithJobsAndLocations(IList<IWebElement> jobElements, string filePath)
    {
        using StreamWriter writer = new StreamWriter(filePath);

        foreach (var jobElement in jobElements)
        {
            var titleElement = jobElement.FindElement(By.CssSelector(".currentOpenings--job-title"));
            var locationElement = jobElement.FindElement(By.CssSelector(".currentOpenings--job-locationWrapper-name"));
            var title = titleElement.Text;
            var location = locationElement.Text;

            writer.WriteLine($"{title}, {location}");
        }
    }

    private void WaitUntilElementIsVisible(By locator, TimeSpan timeout)
    {
        WebDriverWait wait = new WebDriverWait(driver, timeout);
        wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    #endregion

}

