using App.Domain.DTOs;
using App.Domain.Entities;

namespace App.Service.IServices
{
    public interface IEmailOTPService
    {
        Task AddEmailOTPAsync(EmailOTP emailOTP);
        Task<EmailOTP?> GetEmailOTPAsync(EmailOTPDTO email);
        Task UpdateEmailOTPAsync(EmailOTP emailOTP);
    }
}
