using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PS_Selenium_Framework;

namespace PS_Selenium_Framework
{
	public class ProductAddedToCartPopUp
	{

		public ProductAddedToCartPopUp()
		{
			Driver.Instance.SwitchTo().ActiveElement();
		}

		public static bool ContainsProduct(string prodcutName)
		{
			var element = Driver.Instance.FindElement(By.CssSelector("body > div.cm-notification-content.cm-notification-content-extended.notification-content-extended.cm-auto-hide"));
			//WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
			//wait.Until(ExpectedConditions.ElementToBeClickable(element));

			return element.Text.Contains(prodcutName);
		}

		public static void ContinueShopping()
		{
			Driver.Instance.FindElement(By.CssSelector("body > div.cm-notification-content.cm-notification-content-extended.notification-content-extended.cm-auto-hide > div > div.ty-product-notification__buttons.clearfix > div.ty-float-left > a"))
				.Click();
		}

		public static void CheckOut()
		{
			Driver.Instance.FindElement(By.CssSelector("body > div.cm-notification-content.cm-notification-content-extended.notification-content-extended.cm-auto-hide > div > div.ty-product-notification__buttons.clearfix > div.ty-float-right > a"))
				.Click();
		}
	}
}