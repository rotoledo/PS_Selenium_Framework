using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PS_Selenium_Framework
{
	public class ProfilePage
	{
		public static bool IsAt
		{
			get 
			{
				var div_notification = Driver.Instance.FindElement(By.CssSelector("#tygh_container > div.cm-notification-container.notification-container > div"));
				if (div_notification.Text.Contains("O nome de utilizador e/ou palavre passe introduzidos são inválidos. Tente novamente."))
					return false;
				return true;
			}
		}

		public static bool IsLoggedIn
		{
			get
			{
				var myAccountElement = Driver.Instance.FindElement(By.CssSelector("#sw_dropdown_4 > a"));

				//Driver.Wait(5);
				WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
				wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(myAccountElement));

				myAccountElement.Click();
				var accountText = Driver.Instance.FindElement(By.CssSelector("#account_info_4 > ul > li")).Text;

				if (accountText.Contains("@"))
					return true;
				return false;
			}
		}
	}
}
