using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskFullStack.DTOs
{
    public class UserDTO
    {
        [Required]
        public string companyArabicName { get; set; }
        [Required]
        public string companyEnglishName { get; set; }
        [Required, EmailAddress]
        public string email { get; set; }
        [RegularExpression(@"^\+?[\d\s\-().]{7,20}$",
         ErrorMessage = "Please enter a valid phone number")]
        public string? phoneNumber { get; set; }
        [RegularExpression(@"^(https?://)?([\w-]+(\.[\w-]+)+)([/#?]?.*)$", ErrorMessage = "Not Valid Url")]
        public string websiteUrl { get; set; }
        public string? logoUrl { get; set; }
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[\W_]).{6,}$",
    ErrorMessage = "Password must contain at least one capital letter, one number, one special character, and be at least 6 characters long."), DefaultValue("M@261099mm")]
        public string password { get; set; }
        [Required,Compare("password",ErrorMessage ="This Password Not Matched")]
        public string confirmPassword { get; set; }
    }
}
