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
		public string Reference { get; set; }
		public string Category { get; set; }
		public string Partner { get; set; }
		public string DateAndTime { get; set; }
		public string SavingsAmount { get; set; }
		public string Offer { get; set; }

		public SavingsLayout()
		{
			InitializeComponent();

			sav_reference.Text = Reference;
			sav_cat_name.Text = Category;
			sav_part_name.Text = Partner;
			d_and_t.Text = DateAndTime;
			sav_am.Text = SavingsAmount;
			offer_Name.Text = Offer;
			
		}
	}
}