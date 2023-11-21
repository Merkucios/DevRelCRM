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

        public Task DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByNameAsync(string nickName)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
