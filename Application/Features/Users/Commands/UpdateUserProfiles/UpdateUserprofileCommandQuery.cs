using Dtos.WishList;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UpdateUserProfiles
{
    public class UpdateUserprofileCommandQuery : IRequest<WishListResult>
    {
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string LastName { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress), RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov|sa)$")]
        public string Email { get; set; }
        //[Required, DataType(DataType.Password), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$")]
        // public string Password { get; set; }
        public string Phone { get; set; }

       
        public UpdateUserprofileCommandQuery()
        {

        }
        public UpdateUserprofileCommandQuery(string firstName, string lastName, string userName, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Phone = phone;
        }
    }
}
