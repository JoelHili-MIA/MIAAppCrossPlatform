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

using Plugin.Toast;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OfferActivity : Rg.Plugins.Popup.Pages.PopupPage
	{
		FirebaseClient firebase;
		OfferData offer;
		PartnerData partner;
		CategoryData category;

		public OfferActivity()
		{
			InitializeComponent();

			firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");
			GetOfferDetails();
		}

		private void Btn_partnerCode_Clicked(object sender, EventArgs e)//When "Check" button is clicked
		{
			VerifyCode();
		}

		private void Btn_submitDiscount_Clicked(object sender, EventArgs e)//When "Save Discount" button is clicked
		{
			if(et_discountAmount.Text.Length > 0)
			{
				SaveDiscount();
			}
			else
			{
				Plugin.Toast.CrossToastPopUp.Current.ShowToastError("Input the amount");
			}
		}

		private async void ImgBtnClose_Clicked(object sender, EventArgs e)
		{
			await PopupNavigation.Instance.PopAsync();//Close the popup
		}

		protected override bool OnBackgroundClicked()
		{
			return true;//ToTest - Should Close
		}

		private void SaveDiscount()
		{
			SavingsSectionData toSave = new SavingsSectionData
			{

				//Get Random Reference Number
				Reference = GenerateRandom(25),

				//Get The Current Date And Time And Form into (dd-MM-yyyy hh:mm a)
				DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt"),

				//Get Category Name
				CategoryName = category.Name,

				//Get Patner Name
				PartnerName = partner.PartnerName,

				//Get Offer Name
				Offer = offer.OfferName,

				//Get Category ID
				CategoryID = category.Id,

				//Get Partner ID
				PartnerID = partner.PartnerName,

				//Get Offer ID
				OfferID = offer.OfferName,

				//Get Discount Amount
				Savings = string.Format("{0}.2f", float.Parse(et_discountAmount.Text))//ToImplement
			};

			SubmitToFirebase(toSave).Wait();
		}

		private async Task SubmitToFirebase(SavingsSectionData _toSave)
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

		private void VerifyCode()
		{
			if (et_partnerCode.Text.Length == 0)
			{
				Plugin.Toast.CrossToastPopUp.Current.ShowToastWarning("Input the discount code");
			}
			else if(et_partnerCode.Text.Equals(partner.PartnerCode))
			{
				ShowDiscountQuery();
			}
			else
			{
				Plugin.Toast.CrossToastPopUp.Current.ShowToastWarning("Invalid discount code");
			}
		}

		private void ShowDiscountQuery()
		{
			et_partnerCode.Text = "";
			et_partnerCode.IsEnabled = false;

			layoutDiscount.IsVisible = true;
		}

		#region Get All Data Required
		private void GetOfferDetails()
		{
			offer = (OfferData)this.BindingContext;
			GetOfferPartner();
			GetOfferCategory();
		}

		private void GetOfferPartner()
		{
			foreach (PartnerData p in PartnerData.Data)
			{
				foreach (OfferData o in p.Offers)
				{
					if (o.OfferName.Equals(offer.OfferName))
					{
						partner = p;
					}
				}
			}
		}

		private void GetOfferCategory()
		{
			foreach (CategoryData c in CategoryData.Data)
			{
				foreach (PartnerData p in c.Partners)
				{
					if (p.PartnerName.Equals(partner.PartnerName))
					{
						category = c;
					}
				}
			}
		} 
		#endregion
	}
}