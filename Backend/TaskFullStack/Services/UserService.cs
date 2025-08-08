using Microsoft.AspNetCore.Identity;
using TaskFullStack.DTOs;
using TaskFullStack.IRepositories;
using TaskFullStack.IServices;
using TaskFullStack.Models;
using TaskFullStack.RepoUnitOfWork;

namespace TaskFullStack.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        readonly IPasswordHasher<user> _hasher;
        public UserService(IUserRepository userRepository , IPasswordHasher<user> hasher)
        {
            _userRepository = userRepository;
            _hasher = hasher;
        }

        public async Task AddUserAsync(user user)
        {
            await _userRepository.AddUserAsync(user);
        }

        public async Task<user?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<user?> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<user?> GetuserTryLoginAsync(LoginDTO login)
        {
            user? user = await GetUserByEmailAsync(login.Email);
            if (user != null)
            {
                var result = _hasher.VerifyHashedPassword(user, user.password, login.Password);
                if (result == PasswordVerificationResult.Success)
                    return user;
                else return null;

            }
            else return null;
        }

        public async Task UpdateUserAsync(user user)
        {

            await _userRepository.UpdateUserAsync(user);
        }
    }
}
