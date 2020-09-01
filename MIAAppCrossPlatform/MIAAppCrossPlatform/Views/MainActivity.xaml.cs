using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Core;

using Firebase.Database;
using Firebase.Database.Query;
using Plugin.AutoLogin;
using MIAAppCrossPlatform.Models;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainActivity : TabbedPage
	{
		FirebaseClient firebase;
		
		public MainActivity()
		{
			InitializeComponent();

			setProfile();
		}

		private async Task setProfile()
		{
			ProfileData.profile = (ProfileData)(await firebase
				.Child("credentials")
				.OnceAsync<ProfileData>()).Select(i => new ProfileData
				{
					active = i.Object.active,
					email = i.Object.email,
					favorites = i.Object.favorites,
					id = i.Object.id,
					mobile = i.Object.mobile,
					name = i.Object.name,
					password = i.Object.password,
					session = i.Object.session,
					surname = i.Object.surname
				}).Where(i => i.id.Contains(CrossAutoLogin.Current.UserEmail));
		}
	}
}