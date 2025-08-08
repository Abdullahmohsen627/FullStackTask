using TaskFullStack.DTOs;
using TaskFullStack.IRepositories;
using TaskFullStack.IServices;
using TaskFullStack.Models;

namespace TaskFullStack.Services
{
    public class EmailOTPService : IEmailOTPService
    {
        IEmailOTPRepository _emailOTPRepository;
        public EmailOTPService(IEmailOTPRepository emailOTPRepository)
        {
            _emailOTPRepository = emailOTPRepository;
        }
        public async Task AddEmailOTPAsync(EmailOTP emailOTP)
        {
            await _emailOTPRepository.AddEmailOTPAsync(emailOTP);
        }

        public async Task<EmailOTP?> GetEmailOTPAsync(EmailOTPDTO email)
        {
            return await _emailOTPRepository.GetEmailOTPAsync(email);
        }

        public async Task UpdateEmailOTPAsync(EmailOTP emailOTP)
        {
            await _emailOTPRepository.UpdateEmailOTPAsync(emailOTP);
        }
    }
}
