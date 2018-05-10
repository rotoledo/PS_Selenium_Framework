using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS_Selenium_Framework;

namespace Demo_CS_Cart.BuyTests
{
	public class ShopTests : BaseTest
	{

		string productName;

		public ShopTests()
		{
			productName = "Lord of the Rings";
		}

		[TestMethod]
		public void Can_Add_Product_To_Cart()
		{
			HomePage.SearchForProduct(productName);
			SearchResultsPage.SelectFirstResult();
			Assert.IsTrue(ProductDetailPage.IsAtProduct(productName));

			ProductDetailPage.AddToCartCommand().WithQuantity("2").AddToCart();
			Assert.IsTrue(ProductAddedToCartPopUp.ContainsProduct(productName));
		}


		//ProductAddedToCartPage.ContinueShopping();
		//Assert.IsTrue(ProductDetailPopUp.IsAtProduct("Lord of the Rings"));

		//ProductAddedToCartPopUp.CheckOut();
		//Assert.IsTrue(ProductDetailPopUp.IsAtProduct("Lord of the Rings"));

		//Thread.Sleep(3000);
	}
}
