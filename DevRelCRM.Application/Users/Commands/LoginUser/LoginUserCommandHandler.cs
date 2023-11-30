using DevRelCRM.Core.Interfaces.Services;
using DevRelCRM.Infrastructure.Security;
using MediatR;

namespace DevRelCRM.Application.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : 
        IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserService _userService;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public LoginUserCommandHandler(IUserService userService, JwtTokenGenerator jwtTokenGenerator)
        {
            _userService = userService;
            _jwtTokenGenerator = jwtTokenGenerator;

        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByNameAsync(request.NickName, cancellationToken);
            if (user != null)
            {
                if(PasswordHasher.VerifyPassword(request.Password, user.Password))
                {
                    string jwtToken = _jwtTokenGenerator.GenerateToken(user);
                    return jwtToken;
                }
                else
                {
                    throw new Exception("Вы ввели неверный пароль");
                }
            }
            return String.Empty;
        }   
    }
}
