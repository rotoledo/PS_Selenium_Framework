using System;
using OpenQA.Selenium;
using PS_Selenium_Framework;

namespace PS_Selenium_Framework
{
	public class ProductDetailPage
	{

		public static AddToCartCommand AddToCartCommand()
		{
			return new AddToCartCommand();
		}

		public static bool IsAtProduct(string productTitleText)
		{
			var productTitle = Driver.Instance.FindElement(By.CssSelector("#tygh_main_container > div.tygh-content.clearfix > div > div:nth-child(2) > div > div.ty-product-block.ty-product-detail > div.ty-product-block__wrapper.clearfix > div.ty-product-block__left > form > h1 > bdi"));
			if (productTitle.Text.Contains(productTitleText))
				return true;
			return false;
		}
	}

	public class AddToCartCommand
	{
		public string Quantity { get; private set; }


		public AddToCartCommand()
		{
		}

		public AddToCartCommand WithQuantity(string quantity)
		{
			this.Quantity = quantity;
			return this;
		}

		public void AddToCart()
		{
			Driver.Instance.FindElement(By.CssSelector("input[id^='qty_count_']")).Clear();
			Driver.Instance.FindElement(By.CssSelector("input[id^='qty_count_']")).SendKeys(this.Quantity);
			Driver.Instance.FindElement(By.CssSelector("button[id^='button_cart_']")).Click();
		}
	}
}