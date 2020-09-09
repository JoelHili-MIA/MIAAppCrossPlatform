using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Forms.Internals;
using MIAAppCrossPlatform.Models;
using Xamarin.Essentials;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfileFragment : ContentView
	{
		Page alert;

		public ProfileFragment()
		{
			InitializeComponent();

			ID_Card.Text = ProfileData.profile.Id;
			FNAME.Text = ProfileData.profile.Name + " " + ProfileData.profile.Surname;
			Email.Text = ProfileData.profile.Email;
			Mobile_Number.Text = ProfileData.profile.Mobile;
		}

		private async void logoutBtn_Clicked(object sender, EventArgs e)
		{
			bool ans = await alert.DisplayAlert("Log Out","Are you sure you want to log out of your account?","Yes","No");

			if (ans)
			{
				SecureStorage.RemoveAll();
				new LogAndRegActivity();
			}
		}

		private void btn_MySavings_Clicked(object sender, EventArgs e)
		{
			new SavingsSectionActivity();
		}
	}
}