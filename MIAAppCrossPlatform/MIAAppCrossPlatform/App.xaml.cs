using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MIAAppCrossPlatform.Services;
using MIAAppCrossPlatform.Views;
using Xamarin.Auth;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Firebase.Database;
using Firebase.Database.Query;
using MIAAppCrossPlatform.Models;
using System.Linq;

namespace MIAAppCrossPlatform
{
	public partial class App : Application
	{
		public static string User_ID { get; set; }

		public App()
		{
			InitializeComponent();

			DependencyService.Register<MockDataStore>();
			FirebaseHandler.ConfigureFirebase();
			MainPage = new NavigationPage(new LogAndRegActivity());

			_ = LoginAndNavigate();
		}

		private async Task LoginAndNavigate()
		{
			bool isAuthenticated = await AutoLogin(GetUsername(), GetPassword());

			if (isAuthenticated)
			{
				User_ID = GetUsername();
				Console.WriteLine("Auto Accepted");
				MainPage = new NavigationPage(new MainActivity());
			}
			else
			{
				Console.WriteLine("Auto Decline");
				MainPage = new NavigationPage(new LogAndRegActivity());
			}
		}

		private async Task<bool> AutoLogin(string _username, string _password)
		{
			try
			{
				string result = await FirebaseHandler.Login(_username, _password);
				return result.Equals("Logging In");
			}
			catch (Exception)
			{
				return false;
			}
		}

		private string GetUsername()
		{
			var task = Task.Run(() => (SecureStorage.GetAsync("auto_user")));
			if (task.Wait(TimeSpan.FromSeconds(5)))
			{
				return task.Result;
			}
			else
			{
				throw new Exception("Get Username: Timed Out");
			}
		}
		private string GetPassword()
		{
			var task = Task.Run(() => (SecureStorage.GetAsync("auto_pass")));
			if (task.Wait(TimeSpan.FromSeconds(5)))
			{
				return task.Result;
			}
			else
			{
				throw new Exception("Get Password: Timed Out");
			}
		}



		protected override void OnStart()
		{
			FirebaseHandler.ConfigureFirebase();
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
