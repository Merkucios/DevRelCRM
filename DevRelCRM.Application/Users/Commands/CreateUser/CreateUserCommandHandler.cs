using DevRelCRM.Core.DomainModels;
using DevRelCRM.Core.Interfaces.Services;
using DevRelCRM.Infrastructure.Database.PostgreSQL;
using MediatR;

namespace DevRelCRM.Application.Users.Commands.CreateUser
{
    // Обработчик команды для создания нового пользователя
    public class CreateUserCommandHandler :
        IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserService _userService;

        // Конструктор, принимающий контекст базы данных EntityFramework
        public CreateUserCommandHandler(ApplicationDbContext context, IUserService userService)
        {
            _userService = userService;
        }

        // Метод для обработки команды
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Создаем нового пользователя с данными из команды
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Name = request.Name,
                Surname = request.Surname,
                Patronym = request.Patronym,
                Gender = request.Gender,
                NickName = request.NickName,
                Email = request.Email,
                Password = request.Password,
                Role = request.Role,
                DateCreated = DateTime.UtcNow
            };

            // Добавляем пользователя в контекст базы данных и сохраняем изменения
            await _userService.CreateUserAsync(user, cancellationToken);

            // Возвращаем идентификатор созданного пользователя
            return user.UserId;
        }
    }
}
