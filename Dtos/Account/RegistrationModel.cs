using Domian;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Users
{
	public class RegistrationModel
	{
	

		[Required,MinLength(3),MaxLength(100)]
		public string FirstName { get; set; }
        [Required, MinLength(3), MaxLength(100)]
		public string LastName { get; set; }
        [Required, MinLength(3), MaxLength(100)]
		public string UserName { get; set; }
        [Required(ErrorMessage = "The Email Must Match The Regular Expression"), DataType(DataType.EmailAddress), RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov|sa)$")]
        public string Email { get; set; }
        public string phone { get; set; }

        [Required(ErrorMessage = "The Password Must Match The Regular Expression"), DataType(DataType.Password), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$")]
		public string Password { get; set; }
 	      public DateTime Date { get; set; }
        public string? UrlReferralCode { get; set; }
        public string? UserReferralCode { get; set; }

        public RegistrationModel(string firstName, string lastName, string userName, string email, string password,string p,string r,string re)
		{
			FirstName = firstName;
			LastName = lastName;
			UserName = userName;
			Email = email;
			Password = password;
			phone = p;	
			Date = DateTime.Now;
			UserReferralCode = r;
			UrlReferralCode = re;

        }

		public RegistrationModel()
		{

		}
	}


	public static class RegistrationModelExtensions
	{
		public static User ToModel(this RegistrationModel registrationModel)
		{
			return new User
			{
				Fname = registrationModel.FirstName,
                Lname = registrationModel.LastName,
				UserName =registrationModel.UserName,
				Email =registrationModel.Email,
				PhoneNumber=registrationModel.phone,
				CreateAcount=DateTime.Now,
				UrlReferralCode=registrationModel.UrlReferralCode,
			};
		}
	}
}

