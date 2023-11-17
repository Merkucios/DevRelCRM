using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevRelCRM.Core.DomainModels;
using DevRelCRM.Core.Interfaces.Repositories;

namespace DevRelCRM.Infrastructure.Database.PostgreSQL
{
    public class SQLUserRepository : IUserRepository
    {
        // TODO: Добавить имплементацию EntityFramework для PostgreSQL
        
        public Task CreateUserAsync(User user)
        {
            throw new NotImplementedException();
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
