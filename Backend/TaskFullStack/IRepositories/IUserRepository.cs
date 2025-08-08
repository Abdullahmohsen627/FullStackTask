using TaskFullStack.DTOs;
using TaskFullStack.Models;

namespace TaskFullStack.IRepositories
{
    public interface IUserRepository
    {
        public Task AddUserAsync(user user);
        public Task<user?> GetUserByEmailAsync(string Email);
        public Task<user?> GetUserByIdAsync(Guid id);
        public Task<user?> GetuserTryLoginAsync(LoginDTO login);
        public Task UpdateUserAsync(user user);
    }
}
