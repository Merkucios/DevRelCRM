using MediatR;

namespace DevRelCRM.Application.Users.Queries
{
    // Запрос для получения деталей пользователя по идентификатору
        // IRequest<UserDetailsVm> - указывает, что данный запрос ожидает ответ в виде объекта UserDetailsVm
    public class GetUserDetailsQuery : IRequest<UserDetailsVm>
    {
        public Guid UserId { get; set; }
    }
}
