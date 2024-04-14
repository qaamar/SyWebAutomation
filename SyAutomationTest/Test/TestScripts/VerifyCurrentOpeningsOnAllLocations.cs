using NUnit.Framework;
using SyFramework.Page;
namespace SyFramework.Test.TestScripts
{
	public class VerifyCurrentOpeningsOnAllLocations:TestWebBase
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
		public void VerifyCurrentOpeningsOnAllLocationsTest()
		{
			NavigateToUrl();
			homePage.ClickOnCareers();
			careersPage.NavigateToCurrentOpenings();
			careersPage.VerifyNumberOfCurrentOpenings(12);
			CloseWebBrowser();
		}
    }
}

