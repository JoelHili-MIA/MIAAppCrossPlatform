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
	public partial class CategoryLayout : ViewCell
	{
		public string Image { get; set; }
		public string Name { get; set; }

		public CategoryLayout()
		{
			InitializeComponent();

			category_name.Text = Name;
			category_image_icon.Source = Image;
		}
	}
}