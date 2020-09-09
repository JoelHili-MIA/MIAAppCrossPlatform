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
	public partial class FavouritePartners : ViewCell
	{
		public static readonly BindableProperty CategoryNameProperty = BindableProperty.Create("category", typeof(string), typeof(FavouritePartners), "Category");
		public static readonly BindableProperty PartnerImageProperty = BindableProperty.Create("imageSource", typeof(string), typeof(FavouritePartners), "ImageSource");
		public static readonly BindableProperty PartnerNameProperty = BindableProperty.Create("partner", typeof(string), typeof(FavouritePartners), "Partner");

		public string CategoryName
		{
			get { return (string)GetValue(CategoryNameProperty); }
			set { SetValue(CategoryNameProperty, value); }
		}

		public string PartnerImage
		{
			get { return (string)GetValue(PartnerImageProperty); }
			set { SetValue(PartnerImageProperty, value); }
		}

		public string PartnerName
		{
			get { return (string)GetValue(PartnerNameProperty); }
			set { SetValue(PartnerNameProperty, value); }
		}
		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null)
			{
				latestCategory_name.Text = CategoryName;
				latestPartner_image.Source = PartnerImage;
				latestOffer_name.Text = PartnerName;
			}
		}
	}
}