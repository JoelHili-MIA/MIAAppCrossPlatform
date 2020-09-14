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
		private PartnerData partner;
		bool isShowingOffers;
		private FirebaseClient firebase;

		public PartnerActivity()
		{
			CheckFavourite();

			InitializeComponent();

			partner = (PartnerData)this.BindingContext;
			isShowingOffers = false;

			ShowData();
		}

		#region Load the data
		private void ShowData()
		{
			P_name.Text = partner.PartnerName;
			pa_addressData.Text = partner.Address;
			pa_emailData.Text = partner.Email;
			pa_telephoneData.Text = partner.Telephone;
			pa_websiteData.Text = partner.Website;
			pa_tosData.Text = partner.Tos;

			LoadOffers();
		}

		private void LoadOffers()
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
		private void Show_offers_Clicked(object sender, EventArgs e)
		{
			if (isShowingOffers)
			{
				show_offers.Text = "Show Offers";
				isShowingOffers = false;
				HideOffers();
			}
			else
			{
				show_offers.Text = "Hide Offers";
				isShowingOffers = true;
				DisplayOffers();
			}
		}

		private void HideOffers()
		{
			OffersView.Margin = new Thickness(20, 0);
			OffersView.Padding = new Thickness(1);
			PartnerView.IsVisible = true;
		}
		private void DisplayOffers()
		{
			OffersView.Margin = new Thickness(0, 0);
			OffersView.Padding = new Thickness(15);
			PartnerView.IsVisible = false;
		}
		#endregion
		#region Offer Clicked
		private async void Partner_offer_layout_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			OfferData selected = (OfferData)partner_offer_layout.SelectedItem;

			var clickedPage = new OfferActivity
			{
				BindingContext = selected
			};

			await Navigation.PushAsync(clickedPage, true);
		}
		#endregion
		#region Favourites
		private void CheckFavourite()
		{
			if (IsFavourite().Result)//Is Favourited
			{
				add_to_favorites.IconImageSource = ImageSource.FromFile("favoriteFilled.png");
			}
			else//Isn't Favourited
			{
				add_to_favorites.IconImageSource = ImageSource.FromFile("favoriteEmpty.png");
			}
		}

		private async Task<bool> IsFavourite()
		{
			List<FavoriteNameData> favouriteList = (await firebase
											.Child("credentials")
											.Child(ProfileData.profile.Id)
											.Child("favourites")
											.OnceAsync<FavoriteNameData>()).Select(i => new FavoriteNameData
											{
												Name = i.Object.Name
											}).ToList();

			return favouriteList.Where(i => i.Name.Equals(partner.PartnerName)).Equals(partner.PartnerName);
		}

		private void Add_to_favourites_Clicked(object sender, EventArgs e)
		{
			AddToFavourites().Wait();
		}

		private async Task AddToFavourites()
		{
			await firebase
				.Child("credentials")
				.Child(ProfileData.profile.Id)
				.Child("favourites")
				.PostAsync(partner.PartnerName);
		} 
		#endregion
	}
}