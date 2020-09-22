using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MIAAppCrossPlatform.Models
{
	class CategoryData
	{
		public static List<CategoryData> Data;
		public List<PartnerData> Partners { get; set; }

		[JsonProperty ("active", Required = Required.Always)]
		public string Active { get; set; }

		[JsonProperty ("id", Required = Required.Always)]
		public string Id { get; set; }

		[JsonProperty ("name", Required = Required.Always)]
		public string Name { get; set; }

		[JsonProperty ("picUrl", Required = Required.Always)]
		public string PicUrl { get; set; }

		[JsonProperty("urlLink", Required = Required.Always)]
		public string UrlLink { get; set; }
	}
}
