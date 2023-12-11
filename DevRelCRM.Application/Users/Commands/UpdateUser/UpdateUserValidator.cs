using FluentValidation;

namespace DevRelCRM.Application.Users.Commands.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(UpdateUserCommand => UpdateUserCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(UpdateUserCommand => UpdateUserCommand.Name).NotEmpty().MaximumLength(100);
            RuleFor(UpdateUserCommand => UpdateUserCommand.Surname).NotEmpty().MaximumLength(150);
            RuleFor(UpdateUserCommand => UpdateUserCommand.Password).NotEmpty();
        }
    }
}
