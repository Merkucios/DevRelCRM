using System;
using FluentValidation;

namespace DevRelCRM.Application.Users.Queries
{
    public class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            RuleFor(user => user.UserId).NotEqual(Guid.Empty);
        }
    }

}
