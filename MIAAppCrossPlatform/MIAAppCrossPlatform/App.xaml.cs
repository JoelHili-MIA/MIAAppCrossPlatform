using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MIAAppCrossPlatform.Services;
using MIAAppCrossPlatform.Views;
using Plugin.AutoLogin;

namespace MIAAppCrossPlatform
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			DependencyService.Register<MockDataStore>();


			if (CrossAutoLogin.Current.UserIsSaved)
			{
				MainPage = new MainActivity();
			}
			else
			{
				MainPage = new LogAndRegActivity();
			}
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
