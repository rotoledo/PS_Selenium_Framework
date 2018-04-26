using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS_Selenium_Framework;

namespace Demo_CS_Cart_Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestInitialize]
		public void Init()
		{
			Driver.Initialize();
		}

		[TestMethod]
		public void Admin_User_Cant_Login()
		{
			LoginPage.GoTo();
			LoginPage.LoginAs("toledo645@hotmail.com").WithPassword("toledo645Password").Login();

			Assert.IsFalse(ProfilePage.IsAt, "Failed to login");
		}

		[TestCleanup]
		public void CleanUp()
		{
			Driver.Close();
		}

	}
}
