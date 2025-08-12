using System.ComponentModel.DataAnnotations;

namespace App.Domain.DTOs
{
    public class EmailOTPDTO
    {
        [Required, EmailAddress(ErrorMessage = "Not Valid Email")]
        public string Email { get; set; }
        [Required, MinLength(6)]
        public string OTP { get; set; }
    }
}
