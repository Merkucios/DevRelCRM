using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevRelCRM.Core.Interfaces.Repositories;
using DevRelCRM.Core.DomainModels;
using DevRelCRM.Core.Interfaces.Services;

namespace DevRelCRM.Core.DomainServices
{
    public class UserService : IUserService
    {
        // Поведение устанавливается одной из ORM
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.CreateUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<User> GetByNameAsync(string nickName)
        {
            return await _userRepository.GetByNameAsync(nickName);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
