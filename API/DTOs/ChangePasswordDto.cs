using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ChangePasswordDto
    {
        [Required]
        public string ActualPassword{get;set;}
        [Required]
        [StringLength(8,MinimumLength = 4)]
        public string NewPassword{get;set;}
        
    }
}