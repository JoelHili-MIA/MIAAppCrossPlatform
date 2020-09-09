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
	public partial class PartnersActivity : ContentPage
	{
		FirebaseClient firebase;

		public PartnersActivity()
		{
			InitializeComponent();

			firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");

			LoadData();
			LoadList();
		}

		private void LoadList()
		{
			partnerLayout.ItemTemplate = new DataTemplate(typeof(PartnerData));

			var partnerCell = new DataTemplate(typeof(PartnerLayout));
			partnerCell.SetBinding(PartnerLayout.NameProperty, "Name");
			partnerCell.SetBinding(PartnerLayout.ImageSourceProperty, "Image");

			partnerLayout = new ListView
			{
				ItemsSource = PartnerData.Data,
				ItemTemplate = partnerCell
			};
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

		private void LoadData()
		{
			GetCategoryData().Wait();
			GetPartnerData();
		}
	}
}