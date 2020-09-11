using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;
using Firebase.Database.Query;
using MIAAppCrossPlatform.Models;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OfferActivity : Rg.Plugins.Popup.Pages.PopupPage
	{
		FirebaseClient firebase;
		OfferData offer;

		public OfferActivity()
		{
			InitializeComponent();

			firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");
			offer = (OfferData)this.BindingContext;
		}

		private void btn_partnerCode_Clicked(object sender, EventArgs e)//When "Check" button is clicked
		{
			verifyCode();
		}

		private void btn_submitDiscount_Clicked(object sender, EventArgs e)//When "Save Discount" button is clicked
		{
			if(et_discountAmount.Text.Length > 0)
			{
				saveDiscount();
			}
		}

		private async void imgBtnClose_Clicked(object sender, EventArgs e)
		{
			await PopupNavigation.Instance.PopAsync();//Close the popup
		}

		protected override bool OnBackgroundClicked()
		{
			return true;//ToTest - Should Close
		}

		private void saveDiscount()
		{
			SavingsSectionData toSave = new SavingsSectionData();

			//Get Random Reference Number
			toSave.Reference = GenerateRandom(25);

			//Get The Current Date And Time And Form into (dd-MM-yyyy hh:mm a)
			toSave.DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");

			//Get Category Name
			toSave.CategoryName = "";//ToImplement

			//Get Patner Name
			toSave.PartnerName = "";//ToImplement


			//Get Offer Name
			toSave.Offer = offer.offerName;

			//Get Discount Amount
			toSave.Savings = string.Format("{0}.2f",float.Parse(et_discountAmount.Text));//ToImplement

			submitToFirebase(toSave).Wait();
		}

		private async Task submitToFirebase(SavingsSectionData _toSave)
		{
			await firebase
				.Child("credentials")
				.Child(ProfileData.profile.Id)
				.Child("savings")
				.PostAsync(_toSave);
		}

		public static string GenerateRandom(int _size)
		{
			const string allowedCharacters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
			Random random = new Random();
			return new string(Enumerable.Repeat(allowedCharacters, _size).Select(s => s[random.Next(s.Length)]).ToArray());
		}

		private void verifyCode()
		{
			//ToDo
		}
	}
}