using System;
using System.Collections.Generic;
using System.Text;

namespace MIAAppCrossPlatform.Models
{
	class ProfileData
	{
		public static ProfileData profile;
		public string active { get; set; }
		public string email { get; set; }
		public List<FavoriteData> favorites { get; set; }
		public string id { get; set; }
		public string mobile { get; set; }
		public string name { get; set; }
		public string password { get; set; }
		public List<SavingsSectionData> savings { get; set; }
		public string session { get; set; }
		public string surname { get; set; }
	}
}
