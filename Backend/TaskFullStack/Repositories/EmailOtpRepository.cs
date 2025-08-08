using Microsoft.EntityFrameworkCore;
using TaskFullStack.Context;
using TaskFullStack.DTOs;
using TaskFullStack.IRepositories;
using TaskFullStack.Models;

namespace TaskFullStack.Repositories
{
    public class EmailOtpRepository : IEmailOTPRepository
    {
        Data _context;
        public EmailOtpRepository(Data context)
        {

            _context = context;
        }
        public async Task AddEmailOTPAsync(EmailOTP emailOtp)
        {
            await _context.emailOTPs.AddAsync(emailOtp);

        }

        public async Task<EmailOTP?> GetEmailOTPAsync(EmailOTPDTO emailOTPDTO)
        {
            return await _context.emailOTPs.SingleOrDefaultAsync(x => x.Email == emailOTPDTO.Email && x.OTP == emailOTPDTO.OTP);

        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmailOTPAsync(EmailOTP emailOTP)
        {
             _context.emailOTPs.Update(emailOTP);
        }
    }
}
