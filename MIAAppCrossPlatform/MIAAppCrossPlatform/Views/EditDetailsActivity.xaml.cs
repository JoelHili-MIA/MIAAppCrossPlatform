using Firebase.Database;
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
	public partial class EditDetailsActivity : ContentPage
	{
		FirebaseClient firebase;

		public EditDetailsActivity()
		{
			InitializeComponent();

			firebase = new FirebaseClient("https://mia-database-45d86.firebaseio.com");
		}
	}
}