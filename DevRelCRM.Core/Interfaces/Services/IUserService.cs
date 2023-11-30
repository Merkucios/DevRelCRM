using DevRelCRM.Core.DomainModels;

namespace DevRelCRM.Core.Interfaces.Services
{
    // Интерфейс сервиса для работы с пользователями
    public interface IUserService
    {
        public Task CreateUserAsync(User user, CancellationToken cancellationToken);
        public Task UpdateUserAsync(Guid userId, Action<User> updateAction); 
        public Task<User> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<User> GetByNameAsync(string nickName, CancellationToken cancellationToken);
        public Task DeleteUserAsync(Guid userId);

        // Можно добавлять бизнес-логику для поведения

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
