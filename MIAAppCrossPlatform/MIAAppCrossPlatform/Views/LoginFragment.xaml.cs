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
			_ = loginTask();
		}

		private async Task loginTask()
		{
			string response = await FirebaseHandler.Login(et_idCard.Text, et_password.Text);

			if (response.Equals("Logging In"))//Account is good
			{
				Console.WriteLine("Logging In");

				if (chkRemember.IsChecked)
				{
					SaveAutoLogin().Wait();
				}

				await Navigation.PushAsync(new MainActivity());
			}
			else
			{
				validationText.Text = response;
			}
		}

		private void Btn_forgotPassword_Clicked(object sender, EventArgs e)
		{
			_ = forgotPasswordTask();
		}

		private async Task forgotPasswordTask()
		{
			await Navigation.PushAsync(new ForgotPasswordActivity());
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