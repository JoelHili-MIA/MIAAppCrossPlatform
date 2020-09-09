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
	public partial class SavingsSectionActivity : ContentPage
	{
		public SavingsSectionActivity()
		{
			InitializeComponent();

			LoadList();
		}

		private void LoadList()
		{
			savings_layout.ItemTemplate = new DataTemplate(typeof(SavingsLayout));

			var partnerCell = new DataTemplate(typeof(SavingsLayout));
			partnerCell.SetBinding(SavingsLayout.ReferenceProperty, "Reference");
			partnerCell.SetBinding(SavingsLayout.CategoryProperty, "Category");
			partnerCell.SetBinding(SavingsLayout.PartnerProperty, "Partner");
			partnerCell.SetBinding(SavingsLayout.DateAndTimeProperty, "DateAndTime");
			partnerCell.SetBinding(SavingsLayout.SavingsAmountProperty, "SavingsAmount");
			partnerCell.SetBinding(SavingsLayout.OfferProperty, "Offer");

			savings_layout = new ListView
			{
				ItemsSource = ProfileData.profile.Savings,
				ItemTemplate = partnerCell
			};
		}
	}
}