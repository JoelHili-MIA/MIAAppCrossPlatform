using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Forms.Internals;

using Plugin.Toast;
using System.Net.Mail;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterFragment : ContentView
	{
		FirebaseClient firebase;
		bool isCorrect;

		public RegisterFragment()
		{
			InitializeComponent();

			firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");
		}

		private void et_password_Focused(object sender, FocusEventArgs e)
		{
			CrossToastPopUp.Current.ShowToastWarning("Password Policy: A minimum of 8 characters with a combination of Lowercase, uppercase and numbers.");
			
		}

		private void et_idCard_Focused(object sender, FocusEventArgs e)
		{
			CrossToastPopUp.Current.ShowToastWarning("Make sure you are part of the privilege scheme for MIA. Example of ab ID: 0123456M");
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

		private bool checkPassword(string password)
		{
			if(password.Length >= 8)
			{
				bool hasUpperCase = false;
				bool hasLowerCase = false;
				bool hasNumber = false;

				foreach(char c in password)
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

					if(hasNumber && hasLowerCase && hasUpperCase)
					{
						return true;
					}
				}
			}

			return false;
		}

		private void btn_register_Clicked(object sender, EventArgs e)
		{
			isCorrect = true;

			//ID Card
			if (et_idCard.Text.Equals(""))
			{
				isCorrect = false;

				et_idCard.Text = "";
				et_idCard.Placeholder = "Please enter your ID Card";
				et_idCard.PlaceholderColor = Color.Red;
			}
			else
			{
				et_idCard.Placeholder = "ID Card";
				et_idCard.PlaceholderColor = default;
			}

			//Email
			if (et_email.Text.Equals(""))
			{
				isCorrect = false;

				et_email.Text = "";
				et_email.Placeholder = "Please enter your email";
				et_email.PlaceholderColor = Color.Red;
			}
			else if (checkEmail(et_email.Text))
			{
				et_email.Text = "";
				et_email.Placeholder = "Please enter a valid email";
				et_email.PlaceholderColor = Color.Red;
			}
			else
			{
				et_email.Placeholder = "Email";
				et_email.PlaceholderColor = default;
			}

			//Mobile Number
			if (et_mobile.Text.Equals(""))
			{
				isCorrect = false;

				et_mobile.Text = "";
				et_mobile.Placeholder = "Please enter your mobile number";
				et_mobile.PlaceholderColor = Color.Red;
			}
			else if(et_mobile.Text.Length < 8)
			{
				et_mobile.Text = "";
				et_mobile.Placeholder = "Mobile number must be 8 digits long";
				et_mobile.PlaceholderColor = Color.Red;
			}
			else
			{
				et_mobile.Placeholder = "Mobile Number";
				et_mobile.PlaceholderColor = default;
			}

			//Password
			if (et_password.Text.Equals(""))
			{
				isCorrect = false;

				et_password.Text = "";
				et_password.Placeholder = "Please enter a password";
				et_password.PlaceholderColor = Color.Red;
			}
			else if (checkPassword(et_password.Text))
			{
				et_password.Text = "";
				et_password.Placeholder = "Please enter a valid password";
				et_password.PlaceholderColor = Color.Red;
			}
			else
			{
				et_password.Placeholder = "Password";
				et_password.PlaceholderColor = default;
			}

			//Confirm Password
			if (et_repassword.Text.Equals(""))
			{
				isCorrect = false;

				et_repassword.Text = "";
				et_repassword.Placeholder = "Please retype the password";
				et_repassword.PlaceholderColor = Color.Red;
			}
			else if (et_repassword.Text.Equals(et_password.Text))
			{
				et_repassword.Placeholder = "Please enter the same password";
				et_repassword.PlaceholderColor = Color.Red;
			}
			else
			{
				et_repassword.Placeholder = "Confirm Password";
				et_repassword.PlaceholderColor = default;
			}
		}

		private void Register(object sender, EventArgs e)
		{

		}
	}
}