using Firebase.Database;
using Firebase.Database.Query;
using MIAAppCrossPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditDetailsActivity : ContentPage
	{
		FirebaseClient firebase;

		public EditDetailsActivity()
		{
			InitializeComponent();

			firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");
		}

		private bool checkValidation()
		{
			bool isCorrect = true;

			//First Name
			if(edit_first_name.Text.Length == 0)
			{
				isCorrect = false;

				edit_first_name.Text = "";
				edit_first_name.Placeholder = "This field cannot be left blank!";
				edit_first_name.PlaceholderColor = Color.Red;
			}
			else
			{
				edit_first_name.Placeholder = "First Name";
				edit_first_name.PlaceholderColor = default;
			}

			//Last Name
			if(edit_last_name.Text.Length == 0)
			{
				isCorrect = false;

				edit_last_name.Text = "";
				edit_last_name.Placeholder = "This field cannot be left blank!";
				edit_last_name.PlaceholderColor = Color.Red;
			}
			else
			{
				edit_last_name.Placeholder = "Last Name";
				edit_last_name.PlaceholderColor = default;
			}

			//Email Address
			if(edit_email.Text.Length == 0)
			{
				isCorrect = false;

				edit_email.Text = "";
				edit_email.Placeholder = "This field cannot be left blank!";
				edit_email.PlaceholderColor = Color.Red;
			}
			else if (checkEmail(edit_email.Text))
			{
				isCorrect = false;

				edit_email.Text = "";
				edit_email.Placeholder = "Please enter a valid email address!";
				edit_email.PlaceholderColor = Color.Red;
			}
			else
			{
				edit_email.Placeholder = "Email Address";
				edit_email.PlaceholderColor = default;
			}

			//Mobile Number
			if(edit_mobil_number.Text.Length != 8)
			{
				isCorrect = false;

				edit_mobil_number.Text = "";
				edit_mobil_number.Placeholder = "Mobile number must be 8 digist long!";
				edit_mobil_number.PlaceholderColor = Color.Red;
			}
			else
			{
				edit_mobil_number.Placeholder = "Mobile Number";
				edit_mobil_number.PlaceholderColor = default;
			}

			return isCorrect;
		}

		private bool checkEmail(string emailAddress)
		{
			try
			{
				MailAddress m = new MailAddress(emailAddress);
				return true;
			}
			catch
			{
				return false;
			}
		}

		private async Task updateDetails()
		{
			var toUpdate = (await firebase
				.Child("credentials")
				.OnceAsync<ProfileData>()).Where(i => i.Object.Id.Equals(ProfileData.profile.Id)).FirstOrDefault();

			await firebase
				.Child("credentials")
				.Child(toUpdate.Key)
				.PutAsync(new ProfileData()
				{
					Name = edit_first_name.Text,
					Surname = edit_last_name.Text,
					Email = edit_email.Text,
					Mobile = edit_mobil_number.Text
				});
		}

		private async void save_new_details_Clicked(object sender, EventArgs e)
		{
			if (checkValidation())
			{
				bool ans = await DisplayAlert("Are you sure?", "This data will be permanently changed", "Yes", "No");

				if (ans)
				{
					updateDetails().Wait();
					Plugin.Toast.CrossToastPopUp.Current.ShowToastMessage("Profile details have been updated");
				}
			}
		}
	}
}