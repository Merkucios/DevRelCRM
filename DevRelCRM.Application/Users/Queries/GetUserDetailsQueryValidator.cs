using FluentValidation;

namespace DevRelCRM.Application.Users.Queries
{
    // Валидатор для запроса получения деталей пользователя
    public class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            // Устанавливаем правило валидации: идентификатор пользователя не должен быть пустым
            RuleFor(user => user.UserId).NotEqual(Guid.Empty);
        }
    }

}
