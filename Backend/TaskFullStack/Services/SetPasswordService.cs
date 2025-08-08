using Microsoft.AspNetCore.Identity;
using TaskFullStack.IServices;
using TaskFullStack.Models;

namespace TaskFullStack.Services
{
    public class SetPasswordService : ISetPasswordService
    {
        IPasswordHasher<user> _hasher;
        public SetPasswordService(IPasswordHasher<user> hasher)
        {
            _hasher = hasher;
        }
        public async Task SeTPasswordAsync(user user)
        {
            string HashedPassword = _hasher.HashPassword(user, user.password);
            user.password = HashedPassword;
        }
    }
}
