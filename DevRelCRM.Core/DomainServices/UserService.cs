using DevRelCRM.Core.Interfaces.Repositories;
using DevRelCRM.Core.DomainModels;
using DevRelCRM.Core.Interfaces.Services;

namespace DevRelCRM.Core.DomainServices
{
    // Сервис, предоставляющий бизнес-логику для работы с пользователями
    public class UserService : IUserService
    {
        // Репозиторий для взаимодействия с данными пользователей
        private readonly IUserRepository _userRepository;

        // Конструктор, принимающий репозиторий в качестве DI зависимости
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Создает нового пользователя асинхронно
        public async Task CreateUserAsync(User user, CancellationToken cancellationToken)
        {
            await _userRepository.CreateUserAsync(user, cancellationToken);
        }
        
        // Удаляет пользователя асинхронно
        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        // Получает пользователя по его псевдониму (никнейму) асинхронно
        public async Task<User> GetByNameAsync(string nickName)
        {
            return await _userRepository.GetByNameAsync(nickName);
        }

        // Получает пользователя по его идентификатору асинхронно
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        // Получает коллекцию всех пользователей асинхронно
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        // Обновляет информацию о пользователе асинхронно
        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
