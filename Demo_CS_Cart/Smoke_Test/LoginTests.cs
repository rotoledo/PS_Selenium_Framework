using Demo_CS_Cart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS_Selenium_Framework;

namespace Demo_CS_Cart_Tests
{

	[TestClass]
	public class LoginTests : BaseTest
	{

		[TestMethod]
		public void Admin_User_Cant_Login()
		{
			Assert.IsTrue(ProfilePage.IsLoggedIn, "Failed to login");
		}

	}
}
