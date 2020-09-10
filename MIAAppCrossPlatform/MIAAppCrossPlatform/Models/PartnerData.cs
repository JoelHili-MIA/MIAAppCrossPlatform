using System;
using System.Collections.Generic;
using System.Text;

namespace MIAAppCrossPlatform.Models
{
	class PartnerData
	{
		public static List<PartnerData> Data;
		public  List<OfferData> Offers { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string PartnerActive { get; set; }
		public string PartnerCode { get; set; }
		public string PartnerName { get; set; }
		public string PartnerPicUrl { get; set; }
		public string PartnerUrlLink { get; set; }
		public string Telephone { get; set; }
		public string Tos { get; set; }
		public string Website { get; set; }
	}
}
