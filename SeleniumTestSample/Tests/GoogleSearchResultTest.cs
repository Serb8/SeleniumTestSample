using SeleniumTestSample.Pages;
using NUnit.Framework;

namespace SeleniumTestSample.Tests
{
	[TestFixture(Browser.Chrome)]
	[TestFixture(Browser.Firefox)]
	[TestFixture(Browser.Edge)]
	[Parallelizable]
	public class GoogleSearchResultTest : Base
	{

		public GoogleSearchResultTest(Browser browser) : base(browser) { }

		[Test]
		public void Test()
		{
			var googleSearchPage = new GooglePageEl(Driver);
			googleSearchPage.SubmitSearchQuery("trygfonden");
			Assert.IsTrue(googleSearchPage
				.CheckIfFirstSearchResultIsCorrect("TrygFonden vil skabe tryghed i Danmark."));
		}
	}
}