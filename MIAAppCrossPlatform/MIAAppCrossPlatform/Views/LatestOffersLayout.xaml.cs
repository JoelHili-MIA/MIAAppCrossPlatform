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
	public partial class LatestOffersLayout : ViewCell
	{
		public string CategoryName { get; set; }
		public string PartnerImage { get; set; }
		public string OfferName { get; set; }
		public string PartnerName { get; set; }

		public LatestOffersLayout()
		{
			InitializeComponent();

			latestCategory_name.Text = CategoryName;
			latestPartner_image.Source = PartnerImage;
			latestOffer_name.Text = OfferName;
			latestPartner_name.Text = PartnerName;
		}
	}
}