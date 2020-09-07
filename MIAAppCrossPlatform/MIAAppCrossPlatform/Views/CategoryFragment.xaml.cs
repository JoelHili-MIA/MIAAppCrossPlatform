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
		private Entry editText;
		private string currentUserText;

		FirebaseClient firebase;
		FirebaseQuery categories; //Firebase Reference

		public CategoryFragment()
		{
			InitializeComponent();

			GetCategoryData().Wait();
			GetPartnerData();

			currentUserText = "";			

			firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");

			fillListCategory();

			if(CategoryData.Data.Count <= 0)
			{
				searchTextValidation.Text = "Failed to retrieve the categories. Check your internet connection!";
			}
		}

		private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
		{
			currentUserText = sender.ToString();
			filter(currentUserText);
		}

		private void fillListPartner()
		{
			categoryLayout.ItemsSource = PartnerData.Data;
		}

		private List<CategoryData> GetCategoryList()
		{
			return CategoryData.Data.Where(i => i.active == "Yes").ToList();
		}

		private void fillListCategory()
		{
			categoryLayout.ItemsSource = GetCategoryList();
		}

		private void GetPartnerData()
		{
			var query = from PartnerData partner in CategoryData.Data
							   where partner.partnerActive == "Yes"
							   select partner;

			PartnerData.Data = query.ToList();
		}

		private async Task GetCategoryData()
		{
			CategoryData.Data = (await firebase
				.Child("Categories")
				.OnceAsync<CategoryData>()).Select(i => new CategoryData
				{
					partners = i.Object.partners,
					active = i.Object.active,
					id = i.Object.id,
					name = i.Object.name,
					picUrl = i.Object.picUrl,
					urlLink = i.Object.urlLink
				}).ToList();
		}

		private void filter(string input)
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

						if (c.name.ToLower().Contains(input.ToLower()))
						{
							filteredCatList.Add(c);
							searchTextValidation.Text = "";
						}
						if(filteredCatList.Count <= 0)
						{
							searchTextValidation.Text = "No results found. Check if your spelling is correct";
						}

						categoryLayout.ItemsSource = filteredCatList;
					}
					else
					{
						filteredPartList.Clear();
						filteredPartList = new List<PartnerData>();
						PartnerData p = (PartnerData)v;

						if (p.partnerName.ToLower().Contains(input.ToLower()))
						{
							filteredPartList.Add(p);
							searchTextValidation.Text = "";
						}
						if(filteredPartList.Count <= 0)
						{
							searchTextValidation.Text = "No results found. Check if your spelling is correct";
						}

						categoryLayout.ItemsSource = filteredPartList;
					}
				}
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
		}

		private void switchCatPart_Toggled(object sender, ToggledEventArgs e)
		{
			if (catPartSwitch.IsToggled)
			{
				fillListCategory();
			}
			else
			{
				fillListPartner();
			}
		}
	}
}