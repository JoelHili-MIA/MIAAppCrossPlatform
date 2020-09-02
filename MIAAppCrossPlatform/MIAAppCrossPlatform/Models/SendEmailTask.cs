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
		public static void SendEmail(string _from, string _to, string _subject, string _body, string _username, string _password)
		{
			try
			{
				MailMessage mail = new MailMessage();
				SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

				mail.From = new MailAddress(_from);
				mail.To.Add(_to);
				mail.Subject = _subject;
				mail.Body = _body;

				SmtpServer.Port = 587;
				SmtpServer.Credentials = new System.Net.NetworkCredential(_username, _password);
				SmtpServer.Send(mail);

				Plugin.Toast.CrossToastPopUp.Current.ShowToastSuccess("Mail Sent");
			}
			catch(Exception e)
			{
				Plugin.Toast.CrossToastPopUp.Current.ShowToastError(e.Message);
			}
		}
	}
}
