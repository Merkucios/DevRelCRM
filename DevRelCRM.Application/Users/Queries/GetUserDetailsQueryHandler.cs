using AutoMapper;
using DevRelCRM.Infrastructure.Database.PostgreSQL;
using DevRelCRM.Core.DomainModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevRelCRM.Application.Users.Queries
{
    public class GetUserDetailsQueryHandler 
        :IRequestHandler<GetUserDetailsQuery, UserDetailsVm>

    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public GetUserDetailsQueryHandler(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FirstOrDefaultAsync(user =>
                user.UserId == request.UserId);

            if (entity == null || entity.UserId != request.UserId)
            {
                // Сделать NotFoundException.cs
                Console.WriteLine("NotFoundException");

            }

            return _mapper.Map<UserDetailsVm>(entity);
        }
    }
}
