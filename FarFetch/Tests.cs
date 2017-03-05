using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace FarFetch
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Launched");
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void FirstTest()
		{
			//Thread.Sleep(30000);
			app.Tap("skip_intro_btn");
			Thread.Sleep(30000);
			app.Screenshot("We Tapped on the 'Skip' Button");

			app.Tap("onboarding_shop_women");
			Thread.Sleep(30000);
			app.Screenshot("Then We Tapped on 'Shop Women' Button");

			//app.Tap("button_positive");

			app.Tap("button_negative");
			Thread.Sleep(30000);
			app.Screenshot("We Tapped on 'Change' Button");

			app.Tap(x => x.Class("android.widget.TextView").Index(6));
			Thread.Sleep(30000);
			app.Screenshot("Let's pick US and Canada");

			app.Tap(x => x.Class("android.widget.TextView").Index(3));
			Thread.Sleep(30000);
			app.Screenshot("And let's pick US Currency");

			app.Tap("ff_alert_dialog_positive_btn");
			Thread.Sleep(30000);
			app.Screenshot("We will confirm our country and reload the app");

			Thread.Sleep(30000);
			app.WaitForElement(x=> x.Marked("search_header_item"), timeout: TimeSpan.FromSeconds(80));
			app.Tap("search_header_item");
			Thread.Sleep(30000);
			app.Screenshot("Let's Tap on the search icon");

			app.EnterText("Sweaters");
			Thread.Sleep(30000);
			app.Screenshot("We will enter our search, 'Sweaters'");

			app.Tap("search_list_item_text");
			Thread.Sleep(30000);
			app.Screenshot("We will tap the first result");

			app.Tap("product_name_text_view");
			Thread.Sleep(30000);
			app.Screenshot("Then we will tap our sweater");

			app.Tap("add_to_bag_button");
			Thread.Sleep(30000);
			app.Screenshot("Let's put this sweater in our cart");

			app.Tap("select_address_list_item_text_view");
			Thread.Sleep(30000);
			app.Screenshot("Then we will pick our size");

			app.Tap("checkout_button");
			Thread.Sleep(30000);
			app.Screenshot("We Tapped on the Checkout Button");
		}

	}
}
