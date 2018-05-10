using System;
using OpenQA.Selenium;

namespace PS_Selenium_Framework
{
	public class UpperNavigation
	{


		public class MyAccount
		{

			public static IWebElement MyAccountElement = Driver.Instance.FindElement(By.CssSelector("#sw_dropdown_4 > a"));

			public class Register
			{

				public static void Select()
				{
					MenuSelect.Select("sw_dropdown_4", "#account_info_4 > div.ty-account-info__buttons.buttons-container > a.ty-btn.ty-btn__primary");
					// a[data-ca-target-id^='login_block'] + a
				}
			}

			public class Orders
			{
				public static void Select()
				{
					MenuSelect.Select("sw_dropdown_4", "#account_info_4 > ul > li:nth-child(3) > a");
					// #account_info_4 > ul > li:nth-child(3)
					// Driver.Instance.FindElement(By.LinkText("Orders")).Click();
				}
			}



			public class SignIn
			{
				internal static void Select()
				{
					MenuSelect.Select("sw_dropdown_4", "a[data-ca-target-id^='login_block']");
				}

				internal static void InsertEmail(string email)
				{
					Driver.Instance.FindElement(By.Name("user_login")).Clear();
					Driver.Instance.FindElement(By.Name("user_login")).SendKeys(email);
				}

				internal static void InsertPassword(string password)
				{
					Driver.Instance.FindElement(By.Name("password")).Clear();
					Driver.Instance.FindElement(By.Name("password")).SendKeys(password);
				}

				internal static void SignInClick()
				{
					Driver.Instance.FindElement(By.Name("dispatch[auth.login]")).Click();
				}
			}


		}
	}

	public class MenuSelect
	{
		internal static void Select(string topLevelMenuId, string subMenuCssSelector)
		{
			//Driver.WaitForNotificationToDisappearWithTimeOut(10);
			Driver.CloseAlertIfPresent();

			var elementtopLevelMenu = Driver.Instance.FindElement(By.Id(topLevelMenuId));
			Driver.WaitElementToBeClickable(elementtopLevelMenu, 10);
			elementtopLevelMenu.Click();

			var elementSubMenu = Driver.Instance.FindElement(By.CssSelector(subMenuCssSelector));
			Driver.WaitElementToBeClickable(elementSubMenu, 10);
			elementSubMenu.Click();
		}

	}
}