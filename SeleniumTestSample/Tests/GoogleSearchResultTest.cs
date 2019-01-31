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
			googleSearchPage.SubmitSearchQuery("transperfect");
			Assert.IsTrue(googleSearchPage
				.CheckIfFirstSearchResultIsCorrect("TransPerfect Translations is a translation services company based in New York City."));
		}
	}
}