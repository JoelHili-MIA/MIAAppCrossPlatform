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
		public static readonly BindableProperty NameProperty = BindableProperty.Create("name", typeof(string), typeof(PartnerLayout), "Name");
		public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("image", typeof(string), typeof(PartnerLayout), "Image");

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

			if(BindingContext != null)
			{
				latestOffer_name.Text = Name;
				latestPartner_image.Source = ImageSource;
			}
		}
	}
}