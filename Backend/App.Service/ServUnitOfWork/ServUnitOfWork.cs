using App.Domain.DTOs;
using App.Domain.Entities;
using App.Infrastructure.RepoUnitOfWork;
using App.Service.IServices;
using App.Service.Services;
using Microsoft.AspNetCore.Identity;


namespace App.Service.ServUnitOfWork
{
    public class ServUnitOfWork : IServUnitOfWork
    {
        IRepoUnitOfWork _repoUnitOfWork;
        JwtSettings _jwtSettings;
        IPasswordHasher<user> _passwordHasher;
        private readonly IWebHostEnvironment _env;
        IUserService _userService;
        IAuthenticationService _authenticationService;
        IEmailOTPService _emailOTPService;
        IEmailService _emailService;
        IFileService _fileService;
        ISetPasswordService _setPasswordService;
        public ServUnitOfWork(IRepoUnitOfWork repoUnitOfWork, JwtSettings jwtSettings, IPasswordHasher<user> passwordHasher, IWebHostEnvironment env)
        {
            _repoUnitOfWork = repoUnitOfWork;
            _jwtSettings = jwtSettings;
            _passwordHasher = passwordHasher;
            _env = env;
        }
        public IAuthenticationService AuthenticationService => _authenticationService == null ? new AuthenticationService(_jwtSettings) : _authenticationService;

        public IUserService UserService => _userService == null ? new UserService(_repoUnitOfWork.UserRepository, _passwordHasher) : _userService;

        public IEmailOTPService EmailOTPService => _emailOTPService == null ? new EmailOTPService(_repoUnitOfWork.EmailOTPRepository) : _emailOTPService;

        public IEmailService EmailService => _emailService == null ? new EmailService() : _emailService;

        public IFileService FileService => _fileService == null ? new FileService(_env) : _fileService;

        public ISetPasswordService SetPasswordService => _setPasswordService == null ? new SetPasswordService(_passwordHasher) : _setPasswordService;

        public async Task SaveChangesAsync()
        {
            await _repoUnitOfWork.SaveChangesAsync();
        }
    }
}
