using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace PS_Selenium_Framework.Pages
{
	public class OrdersPage
	{
		public static bool IsAt
		{
			get
			{
				return Driver.Instance.Title.Equals("Orders");
			}
		}

		public static void GoTo()
		{
			UpperNavigation.MyAccount.Orders.Select();
		}

		public static int GetOrdersCount()
		{
			if (!IsAt)
				GoTo();

			var tableBody = Driver.Instance.FindElement(By.CssSelector("#pagination_contents > table > tbody"));
			var noOrders = tableBody.FindElements(By.TagName("tr")).Count;
			return noOrders;
		}
	}
}
