using System.ComponentModel.DataAnnotations;

namespace TaskFullStack.DTOs
{
    public class registrationDTO
    {
        [Required]
        public string CompanyArabicName { get; set; }
        [Required]
        public string CompanyEnglishName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"^\+?[\d\s\-().]{7,20}$",
         ErrorMessage = "Please enter a valid phone number")]
        public string? PhoneNumber { get; set; }
        [RegularExpression(@"^(https?://)?([\w-]+(\.[\w-]+)+)([/#?]?.*)$",ErrorMessage ="Not Valid Url")]
        public string WebsiteUrl { get; set; }
        public string? LogoUrl { get; set; }
    }
}
