using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PS_Selenium_Framework
{
	public class HomePage
	{
		public static void GoTo()
		{
			Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress);
			Driver.Instance.Manage().Window.Maximize();

			//Driver.Wait(5);
			//Driver.Instance.FindElement(By.CssSelector("#sw_select_pt_wrap_language")).Click();
			//Driver.Instance.FindElement(By.CssSelector("a[data-ca-country-code='us']")).Click();
		}

		public static LoginCommand LoginAs(string username)
		{
			return new LoginCommand(username);
		}

		public static void SearchForProduct(string product)
		{
			var searchInput = Driver.Instance.FindElement(By.CssSelector("#search_input"));
			searchInput.SendKeys(product + Keys.Enter);
		}

	}


	public class LoginCommand
	{
		private string email;
		private string password;

		public LoginCommand(string username)
		{
			this.email = username;
		}

		public LoginCommand WithPassword(string password)
		{
			this.password = password;
			return this;
		}

		public void Login()
		{
			UpperNavigation.MyAccount.SignIn.Select();
			UpperNavigation.MyAccount.SignIn.InsertEmail(email);
			UpperNavigation.MyAccount.SignIn.InsertPassword(password);
			UpperNavigation.MyAccount.SignIn.SignInClick();
		}


	}

}
