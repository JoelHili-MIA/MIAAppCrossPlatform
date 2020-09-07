using System;
using System.Collections.Generic;
using System.Text;

namespace MIAAppCrossPlatform.Models
{
	class PartnerData
	{
		public static List<PartnerData> Data;
		public List<OfferData> offers { get; set; }
		public string address { get; set; }
		public string email { get; set; }
		public double latitude { get; set; }
		public double longitude { get; set; }
		public string partnerActive { get; set; }
		public string partnerCode { get; set; }
		public string partnerName { get; set; }
		public string partnerPicUrl { get; set; }
		public string partnerUrlLink { get; set; }
		public string telephone { get; set; }
		public string tos { get; set; }
		public string website { get; set; }
	}
}
