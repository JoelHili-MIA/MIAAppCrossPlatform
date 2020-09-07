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
		public PartnerLayout()
		{
			Image image = new Image();
			Label name = new Label();

			InitializeComponent();

			image.SetBinding(Image.SourceProperty, "image");
			name.SetBinding(Label.TextProperty, "name");
		}
	}
}