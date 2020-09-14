using Firebase.Database;
using MIAAppCrossPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Toast;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgotPasswordActivity : ContentPage
	{
		FirebaseClient firebase;

		TimeSpan time;
		private string generatedCode;

		public ForgotPasswordActivity()
		{
			InitializeComponent();

			firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");
		}

		private async Task<bool> CheckEmailExists()
		{
			var tProfile = (await firebase
				.Child("credentials")
				.OnceAsync<ProfileData>()).Where(i => i.Object.Id.Equals(ev_IdCard.Text)).First().Object;

			if(tProfile.Active.Equals("Yes"))//Not yet registered
			{
				CrossToastPopUp.Current.ShowToastError("This ID Card is not yet registered!");

				return false;
			}
			else if(tProfile.Email != "")//Correct
			{
				SendEmail(tProfile);

				return true;
			}
			else//Not avaliable
			{
				CrossToastPopUp.Current.ShowToastError("This ID does not exist!");

				return false;
			}
		}

		private void SendEmail(ProfileData _profile)
		{
			generatedCode = GenerateCode();
			string fromEmail = "miamaltaresetpass@gmail.com".Trim();
			string fromPassword = "Qbim0719";
			string emailSubject = "MIA Privilege Scheme App – Reset of Password";
			string emailBody = "This email has been sent to you because a request was made to reset the password of this app.<br/><br/>Your verification code is: <b>" + generatedCode + "</b><br/><br/>" + "Return to the app and enter this verification code to be able to reset your password.";
			SendEmailTask.SendEmail(fromEmail, _profile.Email, emailSubject, emailBody, fromEmail, fromPassword);
		}

		private string GenerateCode()
		{
			string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			char[] code = new char[8];
			Random r = new Random();

			for(int i = 0; i < code.Length; i++)
			{
				code[i] = chars[r.Next(chars.Length)];
			}

			return new string(code);
		}

		private void BtnSendEmail_Clicked(object sender, EventArgs e)
		{
			btnSendEmail.IsEnabled = false;

			if (CheckEmailExists().Result)
			{
				iv_verification.IsVisible = true;
			}
		}

		private void BtnContinue_Clicked(object sender, EventArgs e)
		{
			double recoveryTime = 3f;
			double startTime = 0f;

			if (ev_msgVerCode.Equals(generatedCode))
			{
				new ChangePasswordActivity();
			}
			else
			{
				startTime = time.TotalSeconds;

				ev_msgVerCode.Text = "";
				ev_msgVerCode.Placeholder = "Invalid Code";
				ev_msgVerCode.PlaceholderColor = Color.Red;
			}

			if((time.TotalSeconds-startTime) == recoveryTime)
			{
				ev_msgVerCode.Placeholder = "Verfication Code";
				ev_msgVerCode.PlaceholderColor = default;
			}
		}
	}
}