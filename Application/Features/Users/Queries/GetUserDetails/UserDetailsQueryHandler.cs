using Domian;
using Dtos.Account;
using Dtos.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetUserDetails
{
    public class UserDetailsQueryHandler : IRequestHandler<UserDetailsQuery, AuthModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        public UserDetailsQueryHandler(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async Task<AuthModel> Handle(UserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.id);
            //return new userDetailsDto {Id=user.Id,Email=user.Email,
            //    UserName=user.UserName,FirstName=user.Fname, LastName= user.Lname  };


            AuthModel authModel = new AuthModel();
            
            var rollist = await _userManager.GetRolesAsync(user);
            authModel.Id = user.Id;
            authModel.IsAuthenticated = true;
            authModel.Email = user.Email!;
            authModel.Username = user.UserName!;
            authModel.Lname = user.Lname!;
            authModel.Fname = user.Fname!;
            authModel.PhoneNumber = user.PhoneNumber!;
            authModel.ExpiresOn =DateTime.Now;
            authModel.Token = "";
            authModel.Roles = rollist.ToList();
            authModel.ReferralCode = user.ReferralCode;
            authModel.UrlReferralCode =user.UrlReferralCode;
            return authModel;


        }
    }
}
