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
		public static readonly BindableProperty NameProperty = BindableProperty.Create("name", typeof(string), typeof(CategoryLayout), "Name");
		public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("image", typeof(string), typeof(CategoryLayout), "Image");

		public string Name
		{
			get { return (string)GetValue(NameProperty); }
			set { SetValue(NameProperty, value); }
		}

		public string ImageSource
		{
			get { return (string)GetValue(ImageSourceProperty); }
			set { SetValue(ImageSourceProperty, value); }
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null)
			{
				category_name.Text = Name;
				category_image_icon.Source = ImageSource;
			}
		}
	}
}