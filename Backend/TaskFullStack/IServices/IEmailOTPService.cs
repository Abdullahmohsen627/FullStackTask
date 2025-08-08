using TaskFullStack.DTOs;
using TaskFullStack.Models;

namespace TaskFullStack.IServices
{
    public interface IEmailOTPService
    {
        Task AddEmailOTPAsync(EmailOTP emailOTP);
        Task<EmailOTP?> GetEmailOTPAsync(EmailOTPDTO email);
        Task UpdateEmailOTPAsync(EmailOTP emailOTP);
    }
}
