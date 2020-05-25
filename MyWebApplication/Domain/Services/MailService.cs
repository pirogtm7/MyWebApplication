using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Domain.Interfaces;
using System.Net.Mail;

namespace MyWebApplication.Domain.Services
{
	public class MailService : IMailService
	{
		private readonly ILogger<MailService> logger;

		public MailService(ILogger<MailService> logger)
		{
			this.logger = logger;
		}

        public void SendEmailCustom(string body, string email, string subject)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("testweblab6@gmail.com");
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("testweblab6@gmail.com", "Test123!");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                logger.LogError(e.GetBaseException().Message);
            }
        }
    }
}
