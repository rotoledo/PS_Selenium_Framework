using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PS_Selenium_Framework.Workflow;

namespace PS_Selenium_Framework
{
	public class Driver
	{
		public static IWebDriver Instance { get; set; }

		public static string Hash = "cfe52f1831e65edc";

		public static string BaseAddress => $@"http://demo.cs-cart.com/stores/{Hash}/?sl=en";

		public static void Initialize()
		{
			Instance = new ChromeDriver();
			TurnOnWait();
			ProductCreator.GetTitle();
		}

		public static void NoWait(Action action)
		{
			TurnOffWait();
			action();
			TurnOnWait();
		}

		private static void TurnOffWait()
		{
			Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
		}

		private static void TurnOnWait()
		{
			Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
		}

		internal static void WaitElementToBeClickable(IWebElement element, int seconds)
		{
			WebDriverWait wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(seconds));
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
		}

		public static void WaitForNotificationToDisappearWithTimeOut(int seconds)
		{
			WebDriverWait wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(seconds));
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
				.InvisibilityOfElementLocated(By.CssSelector("#tygh_container > div.cm-notification-container.notification-container > div")));
		}

		public static void Close()
		{
			Instance.Close();
		}

		public static void Wait(int seconds)
		{
			Thread.Sleep(seconds * 1000);
		}

		public static void CloseAlertIfPresent()
		{
			try
			{
				Driver.Instance.FindElement(By.CssSelector("#tygh_container > div.cm-notification-container.notification-container > div > button")).Click();
			}
			catch (Exception) { }

			try
			{
				Driver.Instance.FindElement(By.CssSelector("#tygh_container > div.cm-notification-container.notification-container > div.cm-notification-content.notification-content.cm-auto-hide.alert-success > button")).Click();
			}
			catch (Exception) { }

			Driver.Wait(2);
			//var element = UpperNavigation.MyAccount.MyAccountElement;
			//WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
			//wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
		}
	}
}