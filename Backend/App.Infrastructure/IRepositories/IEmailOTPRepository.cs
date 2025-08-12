using App.Domain.DTOs;
using App.Domain.Entities;

namespace App.Infrastructure.IRepositories
{
    public interface IEmailOTPRepository
    {
        public Task AddEmailOTPAsync(EmailOTP emailOTP);
        public Task<EmailOTP?> GetEmailOTPAsync(EmailOTPDTO emailOTPDTO);
        public Task UpdateEmailOTPAsync(EmailOTP emailOTP);
    }
}
