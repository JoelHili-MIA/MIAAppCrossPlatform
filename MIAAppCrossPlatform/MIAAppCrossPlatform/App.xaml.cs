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
		readonly FirebaseClient firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");

		public static string User_ID { get; set; }

		public App()
		{
			InitializeComponent();

			DependencyService.Register<MockDataStore>();


			if (AutoLogin(GetUsername().Result, GetPassword().Result))
			{
				User_ID = GetUsername().Result;
				MainPage = new MainActivity();
			}
			else
			{
				MainPage = new LogAndRegActivity();
			}
		}

		private bool AutoLogin(string _username, string _password)
		{
			try
			{
				if (CheckPassword(_username, _password).Result && CheckAccountActive(_username).Result)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		private async Task<string> GetUsername()
		{
			return await SecureStorage.GetAsync("auto_user");
		}
		private async Task<string> GetPassword()
		{
			return await SecureStorage.GetAsync("auto_pass");
		}

		private async Task<bool> CheckPassword(string _username, string _password)
		{
			return (await firebase
				.Child("credentials")
				.Child(_username)
				.OnceAsync<ProfileData>()).Select(p => new ProfileData
				{
					Active = p.Object.Active,
					Email = p.Object.Email,
					Favorites = p.Object.Favorites,
					Id = p.Object.Id,
					Mobile = p.Object.Mobile,
					Name = p.Object.Name,
					Password = p.Object.Password,
					Session = p.Object.Session,
					Surname = p.Object.Surname
				}).Where(q => q.Password.Contains(_password)).Equals(_password);
		}

		private async Task<bool> CheckAccountActive(string _username)
		{
			return (await firebase
				.Child("credentials")
				.Child(_username)
				.OnceAsync<ProfileData>()).Select(p => new ProfileData
				{
					Active = p.Object.Active,
					Email = p.Object.Email,
					Favorites = p.Object.Favorites,
					Id = p.Object.Id,
					Mobile = p.Object.Mobile,
					Name = p.Object.Name,
					Password = p.Object.Password,
					Session = p.Object.Session,
					Surname = p.Object.Surname
				}).Where(q => q.Active.Contains("Yes")).Equals("Yes");
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
