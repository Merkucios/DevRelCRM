using FluentValidation;

namespace DevRelCRM.Application.Users.Commands.LoginUser
{
    /// <summary>
    /// Валидатор для команды входа пользователя в систему.
    /// </summary>
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(loginUserCommand => loginUserCommand.NickName)
                 .NotEmpty()
                 .Must(IsNicknameValid);

            RuleFor(loginUserCommand => loginUserCommand.Password)
                .NotEmpty();

        }

        /// <summary>
        /// Проверяет, что имя пользователя содержит только ASCII символы '-' '_'.
        /// </summary>
        /// <param name="value">Имя пользователя для проверки.</param>
        /// <returns>True, если имя пользователя содержит только допустимые символы.</returns>
        private bool IsNicknameValid(string value) =>
            value?.All(c => char.IsLetterOrDigit(c) || c == '_' || c == '-') ?? true;
    }
}
