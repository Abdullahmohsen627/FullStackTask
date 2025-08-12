using App.Domain.Entities;
using App.Service.IServices;
using Microsoft.AspNetCore.Identity;

namespace App.Service.Services
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
