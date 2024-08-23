using Domian;
using Dtos.WishList;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Features.Users.Commands.UpdateUserProfiles
{
    internal class UpdateUserprofileCommandQueryHandler : IRequestHandler<UpdateUserprofileCommandQuery, WishListResult>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserprofileCommandQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<WishListResult> Handle(UpdateUserprofileCommandQuery request, CancellationToken cancellationToken)
        {
            var userUpdate =await _userRepository.GetByIdAsync(request.Id);
            userUpdate!.Fname = request.FirstName;
            userUpdate.Lname = request.LastName;
            userUpdate.UserName = request.UserName;
            userUpdate.Email = request.Email;
            userUpdate.PhoneNumber = request.Phone;
          


          
           var resulat=await _userRepository.UpdateAsync(userUpdate);
            if (resulat)

                return new WishListResult {Result= "Profile Updated Sucessfully" };

            return new WishListResult {Result="Profile Updated Failed" };
        }
    }
}

