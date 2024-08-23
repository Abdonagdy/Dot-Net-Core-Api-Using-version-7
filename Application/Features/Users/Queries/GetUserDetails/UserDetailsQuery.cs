using Dtos.Account;
using Dtos.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetUserDetails
{
    public class UserDetailsQuery : IRequest<AuthModel>
    {
        public int id { get; set; }
    }
}
