using System;
using System.Runtime.CompilerServices;
using DevRelCRM.Core.DomainModels;
using DevRelCRM.Infrastructure.Database.PostgreSQL;
using MediatR;

namespace DevRelCRM.Application.Users.Commands
{
    public class CreateUserCommandHandler: 
        IRequestHandler<CreateUserCommand, Guid> 
    {
        private readonly ApplicationDbContext _context;

        public CreateUserCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateUserCommand request,  CancellationToken cancellationToken)
        { 
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Name = request.Name,
                Surname = request.Surname,
                Patronym = request.Patronym,
                NickName = request.NickName,
                Email = request.Email,
                Password = request.Password,
                Role = request.Role,
                DateCreated = DateTime.UtcNow
            };

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return user.UserId;
        }
    }
}
