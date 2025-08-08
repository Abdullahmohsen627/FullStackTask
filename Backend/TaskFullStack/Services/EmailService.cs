using System.Net;
using System.Net.Mail;
using TaskFullStack.IRepositories;
using TaskFullStack.IServices;
using TaskFullStack.Models;

namespace TaskFullStack.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "Abdomohse627@gmail.com";
            MailMessage myMail = new MailMessage();
            myMail.From = new MailAddress(mail);
            myMail.To.Add(email);
            myMail.Subject = subject;
            myMail.Body = message;
            var password = "xcbw rmph uuwu qefi";
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(mail, password);
                await client.SendMailAsync(myMail);
            };

        }
    }
}
