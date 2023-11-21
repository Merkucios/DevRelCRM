using MediatR;
using System;

namespace DevRelCRM.Application.Users.Queries
{
    public class GetUserDetailsQuery : IRequest<UserDetailsVm>
    {
        public Guid UserId { get; set; }
    }
}
