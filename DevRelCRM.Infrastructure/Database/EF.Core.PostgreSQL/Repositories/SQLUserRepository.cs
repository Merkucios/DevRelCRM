using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using DevRelCRM.Core.DomainModels;
using DevRelCRM.Core.Interfaces.Repositories;

namespace DevRelCRM.Infrastructure.Database.PostgreSQL.Repositories
{
    // Реализация репозитория пользователей для PostgreSQL базы данных
        // Используя DI можем перейти на любую другую СУБД или ORM
            // Главное наследовать поведение IUserRepository
    public class SQLUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        // Конструктор, принимающий контекст базы данных в качестве зависимости
        public SQLUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user, CancellationToken cancellation)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var user = await GetUserByIdAsync(userId, cancellationToken: CancellationToken.None);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            
        }

        public Task<User> GetByNameAsync(string nickName)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FindAsync(userId, cancellationToken);

            if (entity == null || entity.UserId != userId)
            {
                throw new Exception($"Не найдена запись в БД с {userId}");
            }

            return entity;
        }

        public Task<IEnumerable<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(Guid userId, Action<User> updateAction)        
        {
            User? user = await GetUserByIdAsync(userId, cancellationToken: CancellationToken.None);

            updateAction?.Invoke(user);
            await _context.SaveChangesAsync();
        }
    }
}
