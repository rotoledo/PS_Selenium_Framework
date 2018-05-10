using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace PS_Selenium_Framework.Pages
{
	public class RegistrationPage
	{

		public static RegisterCommand RegisterAs(string email)
		{
			return new RegisterCommand(email);
		}

		public static bool IsAt()
		{
			return Driver.Instance.Title.Equals("Registration")
				&& Driver.Instance.FindElement(By.CssSelector("#tygh_main_container > div.tygh-content.clearfix > div > div:nth-child(2) > div.span8.main-content-grid > div > h1")).Text.Contains("Register for a new account");
		}

		public class RegisterCommand
		{
			public string Email { get; private set; }
			public string Password { get; private set; }
			public string Birthday { get; private set; }

			public RegisterCommand(string email)
			{
				this.Email = email;
			}

			public RegisterCommand WithPassword(string password)
			{
				this.Password = password;
				return this;
			}

			public RegisterCommand WithBirthday(string birthday)
			{
				this.Birthday = birthday;
				return this;
			}

			public void Register()
			{
				Driver.Instance.FindElement(By.Id("email")).SendKeys(this.Email);
				Driver.Instance.FindElement(By.Id("password1")).SendKeys(this.Password);
				Driver.Instance.FindElement(By.Id("password2")).SendKeys(this.Password);
				Driver.Instance.FindElement(By.Id("birthday")).SendKeys(this.Birthday);
				Driver.Instance.FindElement(By.Id("birthday")).SendKeys(Keys.Tab);
				Driver.Instance.FindElement(By.CssSelector("#recaptcha-anchor > div.recaptcha-checkbox-checkmark")).Click();
				Driver.Instance.FindElement(By.Name("dispatch[profiles.update]")).Click();

			}
		}
	}
}
