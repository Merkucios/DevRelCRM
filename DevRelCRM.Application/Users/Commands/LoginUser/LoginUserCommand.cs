using MediatR;

namespace DevRelCRM.Application.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<string>
    {
        public string NickName { get; set; }
        public string Password { get; set; }
    }
}
