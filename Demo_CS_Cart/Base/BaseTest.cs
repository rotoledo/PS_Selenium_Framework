using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS_Selenium_Framework;

namespace Demo_CS_Cart
{
	public class BaseTest
	{

		[TestInitialize]
		public void Init()
		{
			Driver.Initialize();
			HomePage.GoTo();
			HomePage.LoginAs("toledo645@hotmail.com").WithPassword("toledo645Password").Login();
			Driver.CloseAlertIfPresent();
		}

		[TestCleanup]
		public void CleanUp()
		{
			//Driver.Close();
		}
	}
}
