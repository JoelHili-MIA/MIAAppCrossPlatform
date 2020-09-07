using System;
using System.Collections.Generic;
using System.Text;

namespace MIAAppCrossPlatform.Models
{
	class CategoryData
	{
		public static List<CategoryData> Data;
		public List<PartnerData> partners { get; set; }
		public string active { get; set; }
		public string id { get; set; }
		public string name { get; set; }
		public string picUrl { get; set; }
		public string urlLink { get; set; }
	}
}
