using FluentValidation;

namespace DevRelCRM.Application.Users.Commands
{
    // Валидатор для команды создания нового пользователя
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        {
            // Устанавливаем правило валидации: поле Email не должно быть пустым
            RuleFor(createUserCommand =>
                createUserCommand.Email).NotEmpty();
        }
    }
}
