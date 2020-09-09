using System;
using System.Collections.Generic;
using System.Text;

namespace MIAAppCrossPlatform.Models
{
	class ProfileData
	{
		public static ProfileData profile;
		public string Active { get; set; }
		public string Email { get; set; }
		public List<FavoriteData> Favorites { get; set; }
		public string Id { get; set; }
		public string Mobile { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public List<SavingsSectionData> Savings { get; set; }
		public string Session { get; set; }
		public string Surname { get; set; }
	}
}
