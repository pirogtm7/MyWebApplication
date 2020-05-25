using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Domain.Interfaces
{
	public interface IMailService
	{
		void SendEmailCustom(string body, string email, string subject);
	}
}
