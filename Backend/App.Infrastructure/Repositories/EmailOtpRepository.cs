using App.Domain.DTOs;
using App.Domain.Entities;
using App.Infrastructure.Context;
using App.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories
{
    public class EmailOtpRepository : IEmailOTPRepository
    {
        FormDbContext _context;
        public EmailOtpRepository(FormDbContext context)
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
