﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Core;

using Firebase.Database;
using Firebase.Database.Query;
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

			SetProfile().Wait();
		}

		private async Task SetProfile()
		{
			ProfileData.profile = (ProfileData)(await firebase
				.Child("credentials")
				.OnceAsync<ProfileData>()).Select(i => new ProfileData
				{
					Active = i.Object.Active,
					Email = i.Object.Email,
					Favorites = i.Object.Favorites,
					Id = i.Object.Id,
					Mobile = i.Object.Mobile,
					Name = i.Object.Name,
					Password = i.Object.Password,
					Session = i.Object.Session,
					Surname = i.Object.Surname
				}).Where(i => i.Id.Contains(App.User_ID));
		}

		private void ItemTOS_Clicked(object sender, EventArgs e)
		{
			new AboutActivity();
		}

		private void ItemEditProfile_Clicked(object sender, EventArgs e)
		{
			new EditDetailsActivity();
		}

		private void ItemChangePassword_Clicked(object sender, EventArgs e)
		{
			new ChangePasswordActivity();
		}
	}
}