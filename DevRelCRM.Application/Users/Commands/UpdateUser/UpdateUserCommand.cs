using MediatR;

namespace DevRelCRM.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronym { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
