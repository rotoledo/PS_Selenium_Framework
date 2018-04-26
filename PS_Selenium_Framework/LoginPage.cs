using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PS_Selenium_Framework
{
	public class LoginPage
	{
		public static void GoTo()
		{
			Driver.Instance.Navigate().GoToUrl("http://demo.cs-cart.com/");
		}

		public static LoginCommand LoginAs(string username)
		{
			return new LoginCommand(username);
		}
	}

	public class LoginCommand
	{
		private string username;
		private string password;

		public LoginCommand(string username)
		{
			this.username = username;
		}

		public void Login()
		{
			Driver.Instance.FindElement(By.CssSelector("#sw_dropdown_4 > a > span")).Click();
			Driver.Instance.FindElement(By.CssSelector("#login_main_login")).Clear();
			Driver.Instance.FindElement(By.CssSelector("#login_main_login")).SendKeys(username);
			Driver.Instance.FindElement(By.CssSelector("#psw_main_login")).Clear();
			Driver.Instance.FindElement(By.CssSelector("#psw_main_login")).SendKeys(password);

			Driver.Instance.FindElement(By.CssSelector("#tygh_main_container > div.tygh-content.clearfix > div > div:nth-child(2) > div.span8.main-content-grid > div > div > div > form > div.buttons-container.clearfix > div.ty-float-right > button")).Click();
		}

		public LoginCommand WithPassword(string password)
		{
			this.password = password;
			return this;
		}
	}
}
