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
	public partial class PartnerLayout : ViewCell
	{
		public string Image { get; set; }
		public string Name { get; set; }

		public PartnerLayout()
		{
			InitializeComponent();

			latestPartner_image.Source = Image;
			latestOffer_name.Text = Name;
		}
	}
}