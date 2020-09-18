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
		private async Task SaveAutoLogin()
		{
			await SecureStorage.SetAsync("auto_user", et_idCard.Text);
			await SecureStorage.SetAsync("auto_pass", et_password.Text);
		}

		private void Btn_login_Clicked(object sender, EventArgs e)
		{
			string response = FirebaseHandler.Login(et_idCard.Text, et_password.Text).Result;

			if (response.Equals("Logging In"))//Account is good
			{
				if (chkRemember.IsChecked)
				{
					SaveAutoLogin().Wait();
				}

				new MainActivity();//Change to PostAsync
			}
			else
			{
				validationText.Text = response;
			}
		}

		private void Btn_forgotPassword_Clicked(object sender, EventArgs e)
		{
			new ForgotPasswordActivity();
		}

		public static string prefsFile = "miaLog";

		public LoginFragment()
		{
			InitializeComponent();

			chkRemember.IsChecked = false;
			validationText.Text = "";
		}	
	}
}