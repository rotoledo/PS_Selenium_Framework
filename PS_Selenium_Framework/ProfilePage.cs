using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

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
	}
}
