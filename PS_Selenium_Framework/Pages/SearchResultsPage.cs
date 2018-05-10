using System;
using OpenQA.Selenium;
using PS_Selenium_Framework;

namespace PS_Selenium_Framework
{
	public class SearchResultsPage
	{
		public static void SelectFirstResult()
		{
			Driver.Instance.FindElement(By.CssSelector("#pagination_contents > div.grid-list > div:nth-child(1) > div > form > div.ty-grid-list__item-name")).Click();
		}

		public static BuyNowWith1ClickCommand BuyNowWith1Click(string name)
		{
			Driver.Instance.FindElement(By.CssSelector($"a[href^='http://demo.cs-cart.com/stores/{Driver.Hash}/index.php?dispatch=call_requests.request&product_id=']")).Click();
			return new BuyNowWith1ClickCommand(name);
		}


		public class BuyNowWith1ClickCommand
		{
			public string Email { get; private set; }

			public string Name { get; private set; }
			public string Phone { get; private set; }

			public BuyNowWith1ClickCommand(string name)
			{
				this.Name = name;
			}

			public BuyNowWith1ClickCommand WithPhoneNumber(string phone)
			{
				this.Phone = phone;
				return this;
			}

			public BuyNowWith1ClickCommand WithEmail(string email)
			{
				this.Email = email;
				return this;
			}

			public void Submit()
			{
				//Driver.Instance.FindElement(By.CssSelector("#call_data_call_request_88_name")).SendKeys(this.Name);
				//Driver.Instance.FindElement(By.CssSelector("#call_data_call_request_88_phone")).SendKeys(this.Phone);
				Driver.Instance.FindElement(By.Name("call_data[email]")).SendKeys(this.Email);
				Driver.Instance.FindElement(By.Name("dispatch[call_requests.request]")).Click();
			}

		}

	}
}