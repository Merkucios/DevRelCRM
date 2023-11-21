using AutoMapper;
using DevRelCRM.Infrastructure.Database.PostgreSQL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevRelCRM.Application.Users.Queries
{
    // Обработчик запроса для получения деталей пользователя
        // IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
            // <Тип обрабатываемого запроса, тип ответа от обработчика>
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
            // Получаем пользователя из базы данных по указанному идентификатору
            var entity = await _context.Users
                .FirstOrDefaultAsync(user =>
                user.UserId == request.UserId);

            // Проверяем, найден ли пользователь
            if (entity == null || entity.UserId != request.UserId)
            {
                // Сделать NotFoundException.cs
                Console.WriteLine("NotFoundException");

            }

            // Отображаем детали пользователя на объект UserDetailsVm с использованием AutoMapper
            return _mapper.Map<UserDetailsVm>(entity);
        }
    }
}
