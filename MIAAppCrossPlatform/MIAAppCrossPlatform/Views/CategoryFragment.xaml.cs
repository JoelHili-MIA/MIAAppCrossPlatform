using MIAAppCrossPlatform.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryFragment : ContentView
	{
		private DataAdapter dataAdapter;
		private List<CategoryData> categoryDataList;
		private ListView listView;

		public Switch catSwitch, partSwitch;

		private Label searchTextValidation;
		private Entry editText;
		private string currentUserText;

		//ToDo - Add Database Reference

		ActivityIndicator pb;

		public CategoryFragment()
		{
			InitializeComponent();
		}

		private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void filter(string input)
		{
			try
			{
				List<CategoryData> filteredList = new List<CategoryData>();

				foreach(CategoryData c in categoryDataList)
				{
					if (catSwitch.IsToggled)
					{
						if (c.getCategoryName().ToLower().Contains(input.ToLower()))
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
						if (c.getCatPartnerName().ToLower().Contains(input.ToLower()))
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

			}
		}
	}
}