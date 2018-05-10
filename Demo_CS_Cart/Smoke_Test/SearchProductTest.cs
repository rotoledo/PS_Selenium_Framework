using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS_Selenium_Framework;
using PS_Selenium_Framework.Workflow;

namespace Demo_CS_Cart
{

	[TestClass]
	public class SearchProductTest : BaseTest
	{

		[TestMethod]
		public void Can_Search_For_A_Product()
		{
			HomePage.SearchForProduct(ProductCreator.Title);
			SearchResultsPage.SelectFirstResult();
			Assert.IsTrue(ProductDetailPage.IsAtProduct(ProductCreator.Title));
		}

		[TestMethod]
		public void Can_Buy_A_Product()
		{
			HomePage.SearchForProduct(ProductCreator.Title);
			SearchResultsPage.SelectFirstResult();
			Assert.IsTrue(ProductDetailPage.IsAtProduct(ProductCreator.Title));

			SearchResultsPage.BuyNowWith1Click("Roberto de Toledo").WithPhoneNumber("+5551998008029")
				.WithEmail("toledo645@hotmail.com").Submit();
		}



	}
}
