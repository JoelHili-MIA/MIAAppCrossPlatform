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
	public partial class PartnerActivity : ContentPage
	{
		private List<OfferData> offers;
		private PartnerData partner;
		bool isShowingOffers;
		private FirebaseClient firebase;

		public PartnerActivity()
		{
			InitializeComponent();

			partner = (PartnerData)this.BindingContext;
			isShowingOffers = false;

			showData();
		}

		#region Load the data
		private void showData()
		{
			P_name.Text = partner.PartnerName;
			pa_addressData.Text = partner.Address;
			pa_emailData.Text = partner.Email;
			pa_telephoneData.Text = partner.Telephone;
			pa_websiteData.Text = partner.Website;
			pa_tosData.Text = partner.Tos;

			loadOffers();
		}

		private void loadOffers()
		{
			var cell = new DataTemplate(typeof(PartnerOfferRecyclerView));
			cell.SetBinding(PartnerOfferRecyclerView.NameProperty, "Name");

			partner_offer_layout = new ListView
			{
				ItemsSource = partner.Offers,
				ItemTemplate = cell
			};
		}

		#endregion
		#region Handle Show/Hide Offers Button
		private void show_offers_Clicked(object sender, EventArgs e)
		{
			if (isShowingOffers)
			{
				show_offers.Text = "Show Offers";
				isShowingOffers = false;
				hideOffers();
			}
			else
			{
				show_offers.Text = "Hide Offers";
				isShowingOffers = true;
				displayOffers();
			}
		}

		private void hideOffers()
		{
			OffersView.Margin = new Thickness(20, 0);
			OffersView.Padding = new Thickness(1);
			PartnerView.IsVisible = true;
		}
		private void displayOffers()
		{
			OffersView.Margin = new Thickness(0, 0);
			OffersView.Padding = new Thickness(15);
			PartnerView.IsVisible = false;
		}
		#endregion
		#region Offer Clicked
		private async void partner_offer_layout_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			OfferData selected = (OfferData)partner_offer_layout.SelectedItem;

			var clickedPage = new OfferActivity();
			clickedPage.BindingContext = selected;

			await Navigation.PushAsync(clickedPage, true);
		}
		#endregion

		private void add_to_favorites_Clicked(object sender, EventArgs e)
		{
			AddToFavorites().Wait();
		}

		private async Task AddToFavorites()
		{
			await firebase
				.Child("credentials")
				.Child(ProfileData.profile.Id)
				.Child("savings")
				.PostAsync(partner.PartnerName);
		}
	}
}