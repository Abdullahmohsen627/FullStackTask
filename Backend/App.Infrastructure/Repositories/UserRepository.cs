using App.Domain.DTOs;
using App.Domain.Entities;
using App.Infrastructure.Context;
using App.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories
{
    public class userRepository : IUserRepository
    {
        readonly FormDbContext _context;
        public userRepository(FormDbContext context)
        {
            _context = context;
        }
        public async Task AddUserAsync(user user)
        {
            await _context.Users.AddAsync(user);
        }
        public async Task<user?> GetUserByEmailAsync(string Email)
        {
            user? user = await _context.Set<user>().SingleOrDefaultAsync(x => x.email == Email);
            return user;
        }

        public async Task UpdateUserAsync(user user)
        {
            _context.Users.Update(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<user?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.id == id);
        }

        public async Task<user?> GetuserTryLoginAsync(LoginDTO login)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.email == login.Email && x.password == login.Password);
        }
    }
}
