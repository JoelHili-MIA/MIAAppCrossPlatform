using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Core;

using Firebase.Database;
using Firebase.Database.Query;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainActivity : TabbedPage
	{
		CategoryFragment categoryFragment;
		FavoriteFragment favoriteFragment;
		LatestOffersFragment listOFOfferFragment;
		ProfileFragment profileFragment;
		MenuItem prevMenuItem;
		
		public MainActivity()
		{
			InitializeComponent();

			
		}
	}
}