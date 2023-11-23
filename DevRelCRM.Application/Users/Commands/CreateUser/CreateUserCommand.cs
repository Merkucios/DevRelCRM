using MediatR;

namespace DevRelCRM.Application.Users.Commands.CreateUser
{
    // Команда для создания нового пользователя (CQRS)
    public class CreateUserCommand : IRequest<Guid>
    {
        // Свойства, представляющие данные нового пользователя
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronym { get; set; }
        public string Gender { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get;set; }
        public string? Role { get; set; }
    }
}
