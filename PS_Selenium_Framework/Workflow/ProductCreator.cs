using System;
using System.Collections.Generic;
using System.Text;

namespace PS_Selenium_Framework.Workflow
{
    public class ProductCreator
    {

		public static string Title;

		public static void GetTitle()
		{
			string[] Titles = new[] { "Green Lantern", "Batman", "Marvel", "F.E.A.R." }; // "Lord of the Rings"
			Random random = new Random();
			Title = Titles[Titles.Length - 1];
		}
    }
}
