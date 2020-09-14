using MIAAppCrossPlatform.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

using Firebase.Database;
using Firebase.Database.Query;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryFragment : ContentView
	{
		public Switch catPartSwitch; //False - Category; True - Partner

		private Label searchTextValidation;
		private string currentUserText;

		FirebaseClient firebase;

		public CategoryFragment()
		{
			InitializeComponent();

			firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");

			LoadData();

			currentUserText = "";			

			LoadCategoryList(CategoryData.Data);

			if(CategoryData.Data.Count <= 0)
			{
				searchTextValidation.Text = "Failed to retrieve the categories. Check your internet connection!";
			}
		}

		#region Load The Data Required
		private void LoadData()
		{
			GetCategoryData().Wait();//Get Data from "Categories" in the Firebase
			GetPartnerData();//Get Data from CategoriesData Singleton
		}

		private void GetPartnerData()
		{
			var query = from PartnerData partner in CategoryData.Data
						where partner.PartnerActive == "Yes"
						select partner;

			PartnerData.Data = query.ToList();
		}

		private async Task GetCategoryData()
		{
			CategoryData.Data = (await firebase
				.Child("Categories")
				.OnceAsync<CategoryData>()).Select(i => new CategoryData
				{
					Partners = i.Object.Partners,
					Active = i.Object.Active,
					Id = i.Object.Id,
					Name = i.Object.Name,
					PicUrl = i.Object.PicUrl,
					UrlLink = i.Object.UrlLink
				}).ToList();
		}


		private void LoadCategoryList(List<CategoryData> _input)
		{
			categoryLayout.ItemTemplate = new DataTemplate(typeof(CategoryLayout));

			var cell = new DataTemplate(typeof(CategoryLayout));
			cell.SetBinding(CategoryLayout.NameProperty, "Name");
			cell.SetBinding(CategoryLayout.ImageSourceProperty, "Image");

			categoryLayout = new ListView
			{
				ItemsSource = _input,
				ItemTemplate = cell
			};
		}

		private void LoadPartnerList(List<PartnerData> _input)
		{
			categoryLayout.ItemTemplate = new DataTemplate(typeof(PartnerData));

			var partnerCell = new DataTemplate(typeof(PartnerLayout));
			partnerCell.SetBinding(PartnerLayout.NameProperty, "Name");
			partnerCell.SetBinding(PartnerLayout.ImageSourceProperty, "Image");

			categoryLayout = new ListView
			{
				ItemsSource = _input,
				ItemTemplate = partnerCell
			};
		}
		#endregion

		private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
		{
			currentUserText = sender.ToString();
			Filter(currentUserText);
		}

		
		private void Filter(string input)
		{
			try
			{
				List<CategoryData> filteredCatList = new List<CategoryData>();
				List<PartnerData> filteredPartList = new List<PartnerData>();

				foreach (var v in categoryLayout.ItemsSource)
				{
					if (!catPartSwitch.IsToggled)
					{
						filteredCatList.Clear();
						CategoryData c = (CategoryData)v;

						if (c.Name.ToLower().Contains(input.ToLower()))
						{
							filteredCatList.Add(c);
							searchTextValidation.Text = "";
						}
						if(filteredCatList.Count <= 0)
						{
							searchTextValidation.Text = "No results found. Check if your spelling is correct";
						}

						LoadCategoryList(filteredCatList);
					}
					else
					{
						filteredPartList.Clear();
						filteredPartList = new List<PartnerData>();
						PartnerData p = (PartnerData)v;

						if (p.PartnerName.ToLower().Contains(input.ToLower()))
						{
							filteredPartList.Add(p);
							searchTextValidation.Text = "";
						}
						if(filteredPartList.Count <= 0)
						{
							searchTextValidation.Text = "No results found. Check if your spelling is correct";
						}

						LoadPartnerList(filteredPartList);
					}
				}
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
		}

		private void SwitchCatPart_Toggled(object sender, ToggledEventArgs e)
		{
			if (catPartSwitch.IsToggled)
			{
				LoadCategoryList(CategoryData.Data);
			}
			else
			{
				LoadPartnerList(PartnerData.Data);
			}
		}
	}
}