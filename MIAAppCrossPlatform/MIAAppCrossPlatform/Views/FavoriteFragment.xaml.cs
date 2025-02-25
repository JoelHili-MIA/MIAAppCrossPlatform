﻿using Firebase.Database;
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
	public partial class FavoriteFragment : ContentView
	{
		public FavoriteFragment()
		{
			InitializeComponent();

			DisplayData();
		}

		private void DisplayData()
		{
			var FavoriteCell = new DataTemplate(typeof(FavouritePartners));
			FavoriteCell.SetBinding(FavouritePartners.CategoryNameProperty, "Category");
			FavoriteCell.SetBinding(FavouritePartners.PartnerImageProperty, "ImageSource");
			FavoriteCell.SetBinding(FavouritePartners.PartnerNameProperty, "Partner");

			favorite_partners = new ListView
			{
				ItemsSource = ProfileData.profile.Favorites,
				ItemTemplate = FavoriteCell
			};
		}

		private async void Favorite_partners_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			FavoriteData selected = (FavoriteData)favorite_partners.SelectedItem;
			PartnerData partner = PartnerData.Data.First(i => i.PartnerName.ToLower().Equals(selected.PartnerName.ToLower()));

			var clickedPage = new PartnerActivity
			{
				BindingContext = partner
			};

			await Navigation.PushAsync(clickedPage, true);
		}
	}
}