﻿using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace SeleniumTestSample.Pages
{
	public class GooglePageEl
	{
		private IWebDriver driver;

		public GooglePageEl(IWebDriver driver)
		{
			this.driver = driver;
			driver.Navigate().GoToUrl("http://www.google.com/");
		}

		public IWebElement SearchField => driver.FindElement(By.Name("q"));
		public IList<IWebElement> SearchResult => driver.FindElements(By.CssSelector(".g"));


		public void SubmitSearchQuery(string query)
		{
			SearchField.SendKeys(query);
			SearchField.Submit();
		}

		public bool CheckIfFirstSearchResultIsCorrect(string expectedSearchResult)
		{
			return SearchResult.Any(element => element.Text.Contains(expectedSearchResult));
		}

		public string GetPageTitle()
		{
			return driver.Title;
		}
	}
}