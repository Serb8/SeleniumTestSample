using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SeleniumTestSample
{
	public class Base
	{
		internal IWebDriver Driver { get; set; }
		internal Browser BrowserUnderTest { get; set; }
		public enum Browser { Chrome, Firefox, Edge };

		public Base(Browser browser)
		{
			BrowserUnderTest = browser;
		}

		[SetUp]
		public void RunBeforeEachtest()
		{
			var i = (int)BrowserUnderTest;

			switch (i)
			{
				case 0:
					Driver = new ChromeDriver();
					break;
				case 1:
					Driver = new FirefoxDriver();
					break;
				case 2:
					Driver = new EdgeDriver();
					break;
				default:
					throw new ArgumentException("Specified browser is out of supported browsers list.");
			}
			Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
		}

		[TearDown]
		public void RunAfterEachTest()
		{
			Driver.Quit();
		}

		[OneTimeTearDown]
		public void RunAfterAllTests()
		{
			Driver.Quit();
		}
	}
}