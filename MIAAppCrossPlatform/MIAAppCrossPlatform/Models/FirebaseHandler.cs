using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MIAAppCrossPlatform.Models
{
	class FirebaseHandler : LoginHandler
	{
		private static IFirebaseClient Client;

		private static IFirebaseConfig config = new FirebaseConfig
		{
			AuthSecret = "",//Password of Firebase to get data
			BasePath = "https://mia-database-45d86.firebaseio.com/"//Address of Firebase
		};

		public static void ConfigureFirebase()
		{
			Client = new FirebaseClient(config);
		}

		public static async Task<string> Login(string _id, string _password)
		{
			FirebaseResponse response = await Client.GetAsync("credentials/" + _id);
			ProfileData result = response.ResultAs<ProfileData>();

			bool isActive = LoginHandler.CheckAccountActive(result);
			bool isNew = LoginHandler.CheckAccountNew(result);

			if (result.Password.Equals(_password))
			{
				if(isActive && !isNew)//All Good
				{
					return "Logging In";
				}
				else if(isActive && isNew)//New User
				{
					return "Your ID Card is registered in the database! Proceed to the registration page";
				}
				else//Not Active User
				{
					return "The account has been deactivated! Please renew your membership to regain the benefits of this aplication.";
				}
			}
			else//Incorrect
			{
				return "Incorrect ID Card or Password";
			}
		}
	}
}
