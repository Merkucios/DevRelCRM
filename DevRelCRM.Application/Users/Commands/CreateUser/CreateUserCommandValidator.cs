using FluentValidation;

namespace DevRelCRM.Application.Users.Commands.CreateUser
{
    /// <summary>
    /// Валидатор для команды создания нового пользователя.
    /// </summary>
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

        /// <summary>
        /// Проверяет, что имя пользователя содержит только ASCII символы '-' '_'.
        /// </summary>
        /// <param name="value">Имя пользователя для проверки.</param>
        /// <returns>True, если имя пользователя содержит только допустимые символы.</returns>
        private bool IsNicknameValid(string value) =>
            value?.All(c => char.IsLetterOrDigit(c) || c == '_' || c == '-') ?? true;

        /// <summary>
        /// Проверяет, что строка состоит только из букв Unicode.
        /// </summary>
        /// <param name="value">Строка для проверки.</param>
        /// <returns>True, если строка состоит только из букв Unicode.</returns>
        private bool IsUnicodeLetters(string value) =>
            value?.All(char.IsLetter) ?? true;
        

    }
}
