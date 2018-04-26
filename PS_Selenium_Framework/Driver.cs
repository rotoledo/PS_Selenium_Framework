using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PS_Selenium_Framework
{
	public class Driver
	{
		public static IWebDriver Instance { get; set; }

		public static void Initialize()
		{
			Instance = new ChromeDriver();
			Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
		}

		public static void Close()
		{
			Instance.Close();
		}
	}
}