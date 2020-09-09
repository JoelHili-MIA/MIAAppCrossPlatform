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
	public partial class SavingsLayout : ViewCell
	{
		public static readonly BindableProperty ReferenceProperty = BindableProperty.Create("reference", typeof(string), typeof(SavingsLayout), "Reference");
		public static readonly BindableProperty CategoryProperty = BindableProperty.Create("category", typeof(string), typeof(SavingsLayout), "Category");
		public static readonly BindableProperty PartnerProperty = BindableProperty.Create("partner", typeof(string), typeof(SavingsLayout), "Partner");
		public static readonly BindableProperty DateAndTimeProperty = BindableProperty.Create("dateAndTime", typeof(string), typeof(SavingsLayout), "DateAndTime");
		public static readonly BindableProperty SavingsAmountProperty = BindableProperty.Create("savingsAmount", typeof(string), typeof(SavingsLayout), "SavingsAmount");
		public static readonly BindableProperty OfferProperty = BindableProperty.Create("offerProperty", typeof(string), typeof(SavingsLayout), "OfferProperty");

		public string Reference { 
			get { return (string)GetValue(ReferenceProperty); }
			set { SetValue(ReferenceProperty, value); }
		}
		public string Category
		{
			get { return (string)GetValue(CategoryProperty); }
			set { SetValue(CategoryProperty, value); }
		}
		public string Partner
		{
			get { return (string)GetValue(PartnerProperty); }
			set { SetValue(PartnerProperty, value); }
		}
		public string DateAndTime
		{
			get { return (string)GetValue(DateAndTimeProperty); }
			set { SetValue(DateAndTimeProperty, value); }
		}
		public string SavingsAmount
		{
			get { return (string)GetValue(SavingsAmountProperty); }
			set { SetValue(SavingsAmountProperty, value); }
		}
		public string Offer
		{
			get { return (string)GetValue(OfferProperty); }
			set { SetValue(OfferProperty, value); }
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null)
			{
				sav_reference.Text = Reference;//Session Number from profile
				sav_cat_name.Text = Category;//Category Name from CategoryData
				sav_part_name.Text = Partner;//Partner Name from PartnerData
				d_and_t.Text = DateAndTime;//Date and Time when offer was made
				sav_am.Text = SavingsAmount;//How much the user saved
				offer_Name.Text = Offer;//Name of the offer from OfferData
			}
		}
	}
}