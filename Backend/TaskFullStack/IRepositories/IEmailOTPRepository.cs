using TaskFullStack.DTOs;
using TaskFullStack.Models;
using TaskFullStack.Repositories;

namespace TaskFullStack.IRepositories
{
    public interface IEmailOTPRepository
    {
        public Task AddEmailOTPAsync(EmailOTP emailOTP);
        public Task<EmailOTP?> GetEmailOTPAsync(EmailOTPDTO emailOTPDTO);
        public Task UpdateEmailOTPAsync(EmailOTP emailOTP);
    }
}
