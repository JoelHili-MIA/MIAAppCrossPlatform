using System;
using System.Collections.Generic;
using System.Text;

namespace MIAAppCrossPlatform.Models
{
	class LoginHandler
	{
		protected static bool CheckAccountActive(ProfileData _data)
		{
			if (_data.Active.Equals("Yes"))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected static bool CheckAccountNew(ProfileData _data)
		{
			if(_data.Password.Length == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
