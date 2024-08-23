using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Users
{
	public class AuthModel
	{
	
		public int Id { get; set; }
		public string Message { get; set; }
		public bool IsAuthenticated { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
        public string Fname { get; set; }

        public string Lname { get; set; }
        public string Token { get; set; }
		public DateTime ExpiresOn { get; set; }
		public List<string> Roles { get; set; }

        public string? ReferralCode { get; set; }
        public string? UrlReferralCode { get; set; }
        
        public AuthModel(int id,string message, bool isAuthenticated, string username, string email,string phone ,string fname,string lname,string token, DateTime expiresOn ,string r,string re)
		{
			Id = id;
			Message = message;
			IsAuthenticated = isAuthenticated;
			Username = username;
			Email = email;
			PhoneNumber = phone;
			Fname = fname;
			Lname= lname;
			Token = token;
			ExpiresOn = expiresOn;
			Roles = new List<string>();
			ReferralCode = r;
			UrlReferralCode = re;
		}
		public AuthModel() { }
	}
}
