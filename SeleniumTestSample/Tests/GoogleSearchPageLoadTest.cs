using NUnit.Framework;
using SeleniumTestSample.Pages;

namespace SeleniumTestSample.Tests
{
	[TestFixture(Browser.Chrome)]
	[Parallelizable]
	public class GoogleSearchPageLoadTest : Base
	{
		public GoogleSearchPageLoadTest(Browser browser) : base(browser) { }

		[Test]
		public void Test()
		{
			var googleSearchPage = new GooglePageEl(Driver);
			Assert.Multiple(() =>
			{
				Assert.AreEqual("Google", googleSearchPage.GetPageTitle());
				Assert.True(googleSearchPage.SearchField.Displayed);
			});
		}
	}
}