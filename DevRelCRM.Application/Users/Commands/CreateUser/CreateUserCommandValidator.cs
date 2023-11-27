using FluentValidation;

namespace DevRelCRM.Application.Users.Commands.CreateUser
{
    // Валидатор для команды создания нового пользователя
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand => createUserCommand.Name)
                .NotEmpty()
                .Must(IsUnicodeLetters);

            RuleFor(createUserCommand => createUserCommand.Surname)
                .NotEmpty()
                .Must(IsUnicodeLetters);

            RuleFor(createUserCommand => createUserCommand.Patronym)
                .Must(IsUnicodeLetters);

            RuleFor(createUserCommand => createUserCommand.NickName)
                .NotEmpty()
                .Must(IsNicknameValid);

            RuleFor(createUserCommand => createUserCommand.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(createUserCommand => createUserCommand.Password)
                .NotEmpty()
                .MinimumLength(8) 
                .Matches("[A-Z]")
                .Matches("[a-z]")
                .Matches("[0-9]")
                .Matches("[!@#$%^&*(),.?\":{}|<>]");

            RuleFor(createUserCommand => createUserCommand.ConfirmPassword)
                .NotEmpty()
                .Equal(createUserCommand => createUserCommand.Password)
                .WithMessage("Пароли не совпадают");
        }

        private bool IsNicknameValid(string value) =>
            value?.All(c => char.IsLetterOrDigit(c) || c == '_' || c == '-') ?? true;
        private bool IsUnicodeLetters(string value) =>
            value?.All(char.IsLetter) ?? true;
        

    }
}
