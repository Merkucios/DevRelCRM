using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using DevRelCRM.Core.DomainModels;
using DevRelCRM.Core.Interfaces.Repositories;

namespace DevRelCRM.Infrastructure.Database.PostgreSQL.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // TODO: Добавить имплементацию EntityFramework для PostgreSQL

        public async Task CreateUserAsync(User user)
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
