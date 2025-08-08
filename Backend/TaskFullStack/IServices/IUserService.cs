using TaskFullStack.DTOs;
using TaskFullStack.Models;

namespace TaskFullStack.IServices
{
    public interface IUserService
    {
        public Task AddUserAsync(user user);
        public Task<user?> GetUserByEmailAsync(string email);
        public Task<user?> GetUserByIdAsync(Guid id);
        public Task<user?> GetuserTryLoginAsync(LoginDTO login);
        public  Task UpdateUserAsync(user user);
    }
}
