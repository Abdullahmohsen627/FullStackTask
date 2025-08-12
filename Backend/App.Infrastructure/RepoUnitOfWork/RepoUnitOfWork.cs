using App.Infrastructure.Context;
using App.Infrastructure.IRepositories;
using App.Infrastructure.Repositories;

namespace App.Infrastructure.RepoUnitOfWork
{
    public class RepoUnitOfWork : IRepoUnitOfWork
    {
        readonly FormDbContext _context;
        IUserRepository _userRepository;
        IEmailOTPRepository _emailOTPRepository;
        public RepoUnitOfWork(FormDbContext contex) { 
            _context = contex;
        }
        public IUserRepository UserRepository => _userRepository==null?new userRepository(_context):_userRepository ;

        public IEmailOTPRepository EmailOTPRepository => _emailOTPRepository==null ? new EmailOtpRepository(_context): _emailOTPRepository;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
