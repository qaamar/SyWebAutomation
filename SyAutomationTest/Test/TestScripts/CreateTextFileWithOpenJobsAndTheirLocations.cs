using OpenQA.Selenium;
using SyFramework.Page;
using NUnit.Framework;
namespace SyFramework.Test.TestScripts
{
    public class CreateTextFileWithOpenJobsAndTheirLocations : TestWebBase
    {
        private HomePage homePage;
        private CareersPage careersPage;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(Driver);
            careersPage = new CareersPage(Driver);
        }

        [Test]
        public void CreateTextFileWithOpenJobsAndTheirLocationsTest()
        {
            NavigateToUrl();
            homePage.ClickOnCareers();
            careersPage.NavigateToCurrentOpenings();
            careersPage.VerifyNumberOfCurrentOpenings(12);
            IList<IWebElement> jobElements = careersPage.ListOfCurrentOpenings;
            string filePath = "job_positions.txt";
            careersPage.CreateTxtWithJobsAndLocations(jobElements, filePath);
            CloseWebBrowser();
        }
    }
}

