using System.Collections.Generic;
using System.Threading.Tasks;
using DevRelCRM.Core.DomainModels;


namespace DevRelCRM.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task CreateUserAsync(User user);
        public Task UpdateUserAsync(User user);
        public Task<User> GetUserByIdAsync(int userId);
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<User> GetByNameAsync(string nickName);
        public Task DeleteUserAsync(int userId);

        #region Синхронное поведение CRUD
        //public void CreateUser(User user);
        //public void UpdateUser(User user);
        //public User GetUserById(int userId);
        //public IEnumerable<User> GetUsers();
        //public void GetByName(string name);
        //public void DeleteUser(int userId);
        #endregion
    }
}
