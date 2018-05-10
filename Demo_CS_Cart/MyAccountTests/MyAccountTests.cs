using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS_Selenium_Framework;
using PS_Selenium_Framework.Pages;
using PS_Selenium_Framework.Workflow;

namespace Demo_CS_Cart.MyAccountTests
{

	[TestClass]
	public class MyAccountTests : BaseTest
	{
		//[TestMethod]
		public void Can_Register()
		{
			// Go to MyAccount, Register
			Driver.Initialize();
			HomePage.GoTo();

			UpperNavigation.MyAccount.Register.Select();
			Assert.IsTrue(RegistrationPage.IsAt());

			// Fill Registration form
			RegistrationPage.RegisterAs("toledo645@hotmail.com").WithPassword("toledo645Password")
				.WithBirthday("12/06/1985").Register();

			// Check MyAccount if email shows up
			//UpperNavigation.MyAccount.IsLoggedIn();
		}

		[TestMethod]
		public void Added_Products_Show_Up()
		{
			var noOrdersBefore = OrdersPage.GetOrdersCount();

			HomePage.SearchForProduct(ProductCreator.Title);
			SearchResultsPage.SelectFirstResult();
			Assert.IsTrue(ProductDetailPage.IsAtProduct(ProductCreator.Title));

			SearchResultsPage.BuyNowWith1Click("Roberto de Toledo").WithPhoneNumber("+5551998008029")
				.WithEmail("toledo645@hotmail.com").Submit();

			var noOrdersAfter = OrdersPage.GetOrdersCount();

			Assert.AreEqual(noOrdersBefore + 1, noOrdersAfter);
		}

	}
}