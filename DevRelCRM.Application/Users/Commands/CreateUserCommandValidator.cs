using FluentValidation;

namespace DevRelCRM.Application.Users.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        {
            RuleFor(createUserCommand =>
                createUserCommand.Email).NotEmpty();
        }
    }
}
