using DevRelCRM.Core.Interfaces.Services;
using MediatR;

namespace DevRelCRM.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.UpdateUserAsync(request.UserId, entity =>
            {
                entity.Name = request.Name;
                entity.Surname = request.Surname;
                entity.Patronym = request.Patronym;
                entity.Password = request.Password;
                entity.Role = request.Role;
            });

            return Unit.Value;
        }
    }
}
