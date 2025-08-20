using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    public class EmailOTP
    {
        public Guid id { get; set; }
        [Required,EmailAddress(ErrorMessage ="Not Valid Email")]
        public string Email { get; set; }
        [Required,MinLength(6)]
        public string OTP { get; set; }
        [Required]
        public DateTime SendingTime { get; set; }
        [Required,DefaultValue(false)]
        public bool IsValidated { get; set; }

    }
}
