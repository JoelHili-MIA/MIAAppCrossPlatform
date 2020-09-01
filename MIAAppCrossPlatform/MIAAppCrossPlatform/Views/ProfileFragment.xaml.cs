using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.AutoLogin;
using Plugin.AutoLogin.Abstractions;
using Xamarin.Forms.Internals;
using MIAAppCrossPlatform.Models;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfileFragment : ContentView
	{
		FirebaseClient firebase;
		Page alert;

		public ProfileFragment()
		{
			InitializeComponent();

			firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");

			ID_Card.Text = ProfileData.profile.id;
			FNAME.Text = ProfileData.profile.name + " " + ProfileData.profile.surname;
			Email.Text = ProfileData.profile.email;
			Mobile_Number.Text = ProfileData.profile.mobile;
		}

		private async void logoutBtn_Clicked(object sender, EventArgs e)
		{
			bool ans = await alert.DisplayAlert("Log Out","Are you sure you want to log out of your account?","Yes","No");

			if (ans)
			{
				CrossAutoLogin.Current.DeleteUserInfos();
				new LogAndRegActivity();
			}
		}

		private void btn_MySavings_Clicked(object sender, EventArgs e)
		{
			new SavingsSectionActivity();
		}
	}
}