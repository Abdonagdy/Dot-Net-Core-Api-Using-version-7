using System.ComponentModel.DataAnnotations;

namespace Dtos.Users
{
    public class UserMinimalDto
    {
        [Required, MinLength(3), MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string LastName { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string UserName { get; set; }

        public string Phone { get; set; }

        public string? ReferralCode { get; set; }
        public UserMinimalDto(string firstName, string lastName, string userName, string phone,string r)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Phone = phone;
            ReferralCode = r;

        }
        public UserMinimalDto():this(null!, null!, null!,null!,null!)
        {   
        }
    }
}
