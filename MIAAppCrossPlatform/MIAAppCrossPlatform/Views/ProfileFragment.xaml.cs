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