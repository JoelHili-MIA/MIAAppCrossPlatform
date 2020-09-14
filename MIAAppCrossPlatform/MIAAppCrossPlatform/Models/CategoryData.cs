using System;
using System.Collections.Generic;
using System.Text;

namespace MIAAppCrossPlatform.Models
{
	class CategoryData
	{
		public static List<CategoryData> Data;
		public List<PartnerData> Partners { get; set; }
		public string Active { get; set; }
		public string Id { get; set; }
		public string Name { get; set; }
		public string PicUrl { get; set; }
		public string UrlLink { get; set; }
	}
}
