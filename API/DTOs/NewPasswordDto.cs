using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class NewPasswordDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(8,MinimumLength = 4)]
        public string NewPassword{get;set;}
        [Required]
        public string ResetPasswordToken{get;set;}
        
    }
}