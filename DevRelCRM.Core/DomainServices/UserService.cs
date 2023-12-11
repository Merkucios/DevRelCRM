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
        public async Task DeleteUserAsync(Guid userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        // Получает пользователя по его псевдониму (никнейму) асинхронно
        public async Task<User> GetByNameAsync(string nickName, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByNameAsync(nickName, cancellationToken);
        }

        // Получает пользователя по его идентификатору асинхронно
        public async Task<User> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        }

        // Получает коллекцию всех пользователей асинхронно
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        // Обновляет информацию о пользователе асинхронно
        public async Task UpdateUserAsync(Guid userId, Action<User> updateAction)
        {
            await _userRepository.UpdateUserAsync(userId, updateAction);
        }
    }
}
