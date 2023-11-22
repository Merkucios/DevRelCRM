using MediatR;

namespace DevRelCRM.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
    }
}
