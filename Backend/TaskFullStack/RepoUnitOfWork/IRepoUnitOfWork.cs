using TaskFullStack.IRepositories;

namespace TaskFullStack.RepoUnitOfWork
{
    public interface IRepoUnitOfWork
    {
        #region Properties
        public IUserRepository UserRepository { get; }
        public IEmailOTPRepository EmailOTPRepository { get; }

        #endregion
        #region method
        public Task SaveChangesAsync();
        #endregion
    }
}
