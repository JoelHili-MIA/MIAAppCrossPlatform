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

using Plugin.AutoLogin;
using Plugin.AutoLogin.Abstractions;
using MIAAppCrossPlatform.Models;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginFragment : ContentView
	{
		string name, password, currentsession;
		ChildQuery credentials;
		FirebaseClient firebase;

		private void btn_login_Clicked(object sender, EventArgs e)
		{
			if (et_password.Equals(checkPassword().Result))
			{
				new MainActivity();
			}
			else
			{

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