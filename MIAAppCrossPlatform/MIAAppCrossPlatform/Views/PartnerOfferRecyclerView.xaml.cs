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
	public partial class PartnerOfferRecyclerView : ViewCell
	{
		public string Name { get; set; }
		public PartnerOfferRecyclerView()
		{
			InitializeComponent();

			offer_name.Text = Name;
		}
	}
}