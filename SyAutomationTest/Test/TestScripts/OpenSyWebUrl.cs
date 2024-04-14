using NUnit.Framework;

namespace SyFramework.Test.TestScripts
{
    public class OpenSyWebUrl : TestWebBase
	{
		[Test]
		public void OpenSyWebUrlTest()
		{
			NavigateToUrl();
			VerifyCorrectPageUrl("https://symphony.is/");
			CloseWebBrowser();
		}
	}
}

	