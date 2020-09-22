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

		public ProfileData()
		{

		}

		public ProfileData(string _active, string _email, string _id, string _mobile, string _password )
		{
			Active = _active;
			Email = _email;
			Id = _id;
			Mobile = _mobile;
			Password = _password;
		}
	}
}
