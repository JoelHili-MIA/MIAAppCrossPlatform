using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace MIAAppCrossPlatform.Models
{
	class MapData
	{
		private static Position mPosition;
		private static string mTitle;

		public MapData(double _latitude, double _longitude, string _title)
		{
			mPosition = new Position(_latitude, _longitude);
			mTitle = _title;
		}

		public static Position getPosition()
		{
			return mPosition;
		}

		public static string getTitle()
		{
			return mTitle;
		}
	}
}
