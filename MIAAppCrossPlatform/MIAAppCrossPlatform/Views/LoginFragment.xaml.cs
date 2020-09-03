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
		string name, password, currentsession;
		ChildQuery credentials;
		FirebaseClient firebase;

		private async Task saveAutoLogin()
		{
			await SecureStorage.SetAsync("auto_user", et_idCard.Text);
			await SecureStorage.SetAsync("auto_pass", et_password.Text);
		}

		private void btn_login_Clicked(object sender, EventArgs e)
		{
			bool resultCheckPassword = checkPassword().Result;
			bool resultCheckAccountActive = checkAccountActive().Result;
			bool resultCheckAccountNew = checkAccountNew().Result;

			if (resultCheckPassword && !resultCheckAccountNew && resultCheckAccountActive)//Account is good
			{
				if (chkRemember.IsChecked)
				{
					saveAutoLogin().Wait();
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

		private async Task<bool> checkPassword()
		{
			return (await firebase
				.Child("credentials")
				.Child(et_idCard.Text)
				.OnceAsync<ProfileData>()).Select(p => new ProfileData
				{
					active = p.Object.active,
					email = p.Object.email,
					favorites = p.Object.favorites,
					id = p.Object.id,
					mobile = p.Object.mobile,
					name = p.Object.name,
					password = p.Object.password,
					session = p.Object.session,
					surname = p.Object.surname
				}).Where(q => q.password.Contains(et_password.Text)).Equals(et_password);
		}

		private async Task<bool> checkAccountActive()
		{
			return (await firebase
				.Child("credentials")
				.Child(et_idCard.Text)
				.OnceAsync<ProfileData>()).Select(p => new ProfileData
				{
					active = p.Object.active,
					email = p.Object.email,
					favorites = p.Object.favorites,
					id = p.Object.id,
					mobile = p.Object.mobile,
					name = p.Object.name,
					password = p.Object.password,
					session = p.Object.session,
					surname = p.Object.surname
				}).Where(q => q.active.Contains("Yes")).Equals("Yes");
		}

		private async Task<bool> checkAccountNew()
		{
			return (await firebase
				.Child("credentials")
				.Child(et_idCard.Text)
				.OnceAsync<ProfileData>()).Select(p => new ProfileData
				{
					active = p.Object.active,
					email = p.Object.email,
					favorites = p.Object.favorites,
					id = p.Object.id,
					mobile = p.Object.mobile,
					name = p.Object.name,
					password = p.Object.password,
					session = p.Object.session,
					surname = p.Object.surname
				}).Where(q => q.password.Contains("")).Equals("");
		}

		private void btn_forgotPassword_Clicked(object sender, EventArgs e)
		{
			new ForgotPasswordActivity();
		}

		public static string prefsFile = "miaLog";

		public LoginFragment()
		{
			InitializeComponent();

			chkRemember.IsChecked = false;
			buffer.IsVisible = false;
			validationText.Text = "";

			firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");
			credentials = firebase.Child("credentials");
		}	
	}
}