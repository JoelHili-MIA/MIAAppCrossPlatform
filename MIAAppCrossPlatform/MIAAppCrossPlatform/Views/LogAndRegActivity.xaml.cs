﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIAAppCrossPlatform.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogAndRegActivity : TabbedPage
	{
		public LogAndRegActivity()
		{
			InitializeComponent();

			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}