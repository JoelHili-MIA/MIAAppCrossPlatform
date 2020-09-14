using Firebase.Database;
using Firebase.Database.Query;
using MIAAppCrossPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChangePasswordActivity : ContentPage
	{
		FirebaseClient firebase;
		public ChangePasswordActivity()
		{
			InitializeComponent();

			firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");
		}

		private bool CheckPassword(string password)
		{
			if (password.Length >= 8)
			{
				bool hasUpperCase = false;
				bool hasLowerCase = false;
				bool hasNumber = false;

				foreach (char c in password)
				{
					if (char.IsLower(c))
					{
						hasUpperCase = true;
					}
					else if (char.IsUpper(c))
					{
						hasLowerCase = true;
					}
					else if (char.IsDigit(c))
					{
						hasNumber = true;
					}

					if (hasNumber && hasLowerCase && hasUpperCase)
					{
						return true;
					}
				}
			}

			return false;
		}

		private void Save_new_password_Clicked(object sender, EventArgs e)
		{
			bool isCorrect = true;

			//Password
			if (edit_new_password.Text.Equals(""))
			{
				isCorrect = false;

				edit_new_password.Text = "";
				edit_new_password.Placeholder = "Please enter a password";
				edit_new_password.PlaceholderColor = Color.Red;
			}
			else if (CheckPassword(edit_new_password.Text))
			{
				edit_new_password.Text = "";
				edit_new_password.Placeholder = "Please enter a valid password";
				edit_new_password.PlaceholderColor = Color.Red;
			}
			else
			{
				edit_new_password.Placeholder = "Password";
				edit_new_password.PlaceholderColor = default;
			}

			//Confirm Password
			if (edit_confirm_new_password.Text.Equals(""))
			{
				isCorrect = false;

				edit_confirm_new_password.Text = "";
				edit_confirm_new_password.Placeholder = "Please retype the password";
				edit_confirm_new_password.PlaceholderColor = Color.Red;
			}
			else if (edit_confirm_new_password.Text.Equals(edit_new_password.Text))
			{
				edit_confirm_new_password.Placeholder = "Please enter the same password";
				edit_confirm_new_password.PlaceholderColor = Color.Red;
			}
			else
			{
				edit_confirm_new_password.Placeholder = "Confirm Password";
				edit_confirm_new_password.PlaceholderColor = default;
			}

			if (isCorrect)
			{
				SavePassword().Wait();
				Plugin.Toast.CrossToastPopUp.Current.ShowToastMessage("Changed Password");
			}
		}

		private async Task SavePassword()
		{
			var toUpdate = (await firebase
				.Child("credentials")
				.OnceAsync<ProfileData>()).Where(i => i.Object.Id.Equals(ProfileData.profile.Id)).FirstOrDefault();

			await firebase
				.Child("credentials")
				.Child(toUpdate.Key)
				.PutAsync(new ProfileData()
				{
					Password = edit_new_password.Text
				});
		}
	}
}