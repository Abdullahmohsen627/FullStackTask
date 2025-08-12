using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class user
    {
        public Guid id { get; set; }
        [Required]
        public string companyArabicName { get; set; }
        [Required]
        public string companyEnglishName { get; set; }
        [Required, EmailAddress]
        public string email { get; set; }
        [RegularExpression(@"^\+?[\d\s\-().]{7,20}$",
         ErrorMessage = "Please enter a valid phone number")]
        public string? phoneNumber { get; set; }
        [RegularExpression(@"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$")]
        public string websiteUrl { get; set; }
        public string? LogoUrl { get; set; }

        [RegularExpression(@"^(?=.[A-Z])(?=.[0-9])(?=.[!@#$%^&()_+\-=\[\]{};':""\\|,.<>\/?]).{6,}$",
     ErrorMessage = "Password must contain at least one capital letter, one number, one special character, and be at least 6 characters long."), DefaultValue("M@261099mm")]
        public string password { get; set; }



    }
}
