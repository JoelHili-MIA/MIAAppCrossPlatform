using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MIAAppCrossPlatform.Models
{
	class SendEmailTask
	{
		public static async Task SendEmail( String _subject, String _body, List<string> _recipient)
		{
			try
			{
				var message = new EmailMessage
				{
					Subject = _subject,
					Body = _body,
					To = _recipient,
				};

				await Email.ComposeAsync(message);
			}
			catch(FeatureNotEnabledException fnsEx)
			{
				//Email not supported on this device
				Console.WriteLine(fnsEx);
			}
			catch(Exception ex)
			{
				//Other Exception
				Console.WriteLine(ex);
			}
		}
	}
}
