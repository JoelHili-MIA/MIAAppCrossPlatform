using Firebase.Database;
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
	public partial class AboutActivity : ContentPage
	{
		readonly FirebaseClient firebase;
		string hyperlink = "";

		public AboutActivity()
		{
			InitializeComponent();

			AboutData ad = GetInstructions().Result;

			tos.Text = ad.appTOS;
			privacyPolicyText.Text = ad.appPrivacyPolicy;
			appInstructionsText.Text = ad.appInstructions;

			website_link.Text = hyperlink;
		}

		private async Task<AboutData> GetInstructions()
		{
			return (await firebase
				.Child("app-about")
				.OnceAsync<AboutData>()).Select(i => new AboutData
				{
					appInstructions = i.Object.appInstructions,
					appPrivacyPolicy = i.Object.appPrivacyPolicy,
					appTOS = i.Object.appTOS
				}).First();
		}
	}
}