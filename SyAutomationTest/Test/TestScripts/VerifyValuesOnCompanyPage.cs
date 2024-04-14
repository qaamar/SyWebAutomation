using System;
using SyFramework.Page;
using NUnit.Framework;

namespace SyFramework.Test.TestScripts
{
	public class VerifyValuesOnCompanyPage : TestWebBase
	{
        private HomePage homePage;
        private CompanyPage companyPage;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(Driver);
            companyPage = new CompanyPage(Driver);
        }

        [Test]
        public void VerifyValuesOnCompanyPageTest()
		{
            NavigateToUrl();
            homePage.CickOnCompany();
            VerifyCorrectPageUrl("https://symphony.is/about-us/company");
            companyPage.VerifyCompanyInformation();
            CloseWebBrowser();
        }
	}
}

