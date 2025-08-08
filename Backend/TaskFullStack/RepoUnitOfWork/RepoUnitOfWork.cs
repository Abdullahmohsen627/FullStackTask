using TaskFullStack.Context;
using TaskFullStack.IRepositories;
using TaskFullStack.Repositories;

namespace TaskFullStack.RepoUnitOfWork
{
    public class RepoUnitOfWork : IRepoUnitOfWork
    {
        readonly Data _context;
        IUserRepository _userRepository;
        IEmailOTPRepository _emailOTPRepository;
        public RepoUnitOfWork(Data contex) { 
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
