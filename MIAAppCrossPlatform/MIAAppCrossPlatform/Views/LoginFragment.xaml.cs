using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using MIAAppCrossPlatform.Models;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginFragment : ContentView
	{
		FirebaseClient firebase;

		private async Task SaveAutoLogin()
		{
			await SecureStorage.SetAsync("auto_user", et_idCard.Text);
			await SecureStorage.SetAsync("auto_pass", et_password.Text);
		}

		private void Btn_login_Clicked(object sender, EventArgs e)
		{
			bool resultCheckPassword = CheckPassword().Result;
			bool resultCheckAccountActive = CheckAccountActive().Result;
			bool resultCheckAccountNew = CheckAccountNew().Result;

			if (resultCheckPassword && !resultCheckAccountNew && resultCheckAccountActive)//Account is good
			{
				if (chkRemember.IsChecked)
				{
					SaveAutoLogin().Wait();
				}

				new MainActivity();
			}
			else if (resultCheckPassword && !resultCheckAccountNew && !resultCheckAccountActive)//Account is not active
			{
				validationText.Text = "The account has been deactivated! Please renew your membership to regain the benefits of this aplication.";
			}
			else if (resultCheckAccountNew)//Account is new
			{
				validationText.Text = "Your ID Card is registered in the database! Proceed to the registration page";
			}
			else if (!resultCheckPassword && !resultCheckAccountActive && !resultCheckAccountNew)//Account does not exist
			{
				validationText.Text = "Account does not exist";
			}
			else if (!resultCheckPassword)//Incorrect Password
			{
				validationText.Text = "Incorrect ID Card or Password";
			}
		}

		private async Task<bool> CheckPassword()
		{
			return (await firebase
				.Child("credentials")
				.Child(et_idCard.Text)
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
				}).Where(q => q.Password.Contains(et_password.Text)).Equals(et_password);
		}

		private async Task<bool> CheckAccountActive()
		{
			return (await firebase
				.Child("credentials")
				.Child(et_idCard.Text)
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

		private async Task<bool> CheckAccountNew()
		{
			return (await firebase
				.Child("credentials")
				.Child(et_idCard.Text)
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
				}).Where(q => q.Password.Contains("")).Equals("");
		}

		private void Btn_forgotPassword_Clicked(object sender, EventArgs e)
		{
			new ForgotPasswordActivity();
		}

		public static string prefsFile = "miaLog";

		public LoginFragment()
		{
			InitializeComponent();

			chkRemember.IsChecked = false;
			validationText.Text = "";

			firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");
		}	
	}
}