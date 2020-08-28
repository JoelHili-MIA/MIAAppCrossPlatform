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
		private DataAdapter dataAdapter;
		private List<CategoryData> categoryDataList;
		private ListView listView;

		public Switch catPartSwitch;

		private Label searchTextValidation;
		private Entry editText;
		private string currentUserText;

		FirebaseClient firebase;
		FirebaseQuery categories; //Firebase Reference

		public CategoryFragment()
		{
			InitializeComponent();

			listView = (ListView)FindByName("categoryLayout");
			searchEditText = (SearchBar)FindByName("searchEditText");
			catPartSwitch = (Switch)FindByName("switchCatPart"); //False - Category; True - Partner

			currentUserText = "";			

			firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");
			categories = firebase.Child("Categories");

			fillListPartner();

			if(categoryDataList.Count <= 0)
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
			categoryDataList = new List<CategoryData>();

			try
			{
				GetPartnerList();
				
			}
			catch
			{

			}
		}

		private bool GetPartnerList()
		{
			return false; //ToDo
		}

		private void fillListCategory()
		{
			categoryDataList.Clear();
			categoryDataList = GetCategoryList().Result;
		}

		private async Task<List<CategoryData>> GetCategoryList()
		{
			return (await firebase
				.Child("categories")
				.OnceAsync<CategoryData>()).Select(i => new CategoryData
				{
					
				}).ToList();
		}

		private void filter(string input)
		{
			try
			{
				List<CategoryData> filteredList = new List<CategoryData>();

				foreach(CategoryData c in categoryDataList)
				{
					if (!catPartSwitch.IsToggled)
					{
						if (c.name.ToLower().Contains(input.ToLower()))
						{
							filteredList.Add(c);
							searchTextValidation.Text = "";
						}
						if(filteredList.Count <= 0)
						{
							searchTextValidation.Text = "No results found. Check if your spelling is correct";
						}
					}
					else
					{
						if (c.partners.FirstOrDefault<PartnerData>().partnerName.ToLower().Contains(input.ToLower()))
						{
							filteredList.Add(c);
							searchTextValidation.Text = "";
						}
						if(filteredList.Count <= 0)
						{
							searchTextValidation.Text = "No results found. Check if your spelling is correct";
						}
					}
				}

				listView.ItemsSource = filteredList;
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