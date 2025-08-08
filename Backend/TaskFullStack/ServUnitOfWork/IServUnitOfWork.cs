using TaskFullStack.IServices;

namespace TaskFullStack.ServUnitOfWork
{
    public interface IServUnitOfWork
    {
        IAuthenticationService AuthenticationService { get; }
        IUserService UserService { get; }
        IEmailOTPService EmailOTPService { get; }
        IEmailService EmailService { get; }
        IFileService FileService { get; }
        ISetPasswordService SetPasswordService { get; }
        Task SaveChangesAsync();
    }
}
