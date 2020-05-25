using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyWebApplication.Domain.Models
{
	public class AppUser : IdentityUser
	{
		public string City { get; set; }
		public string Country { get; set; }
	}
}
