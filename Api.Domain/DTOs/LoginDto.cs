using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email is not valid.")]
        [StringLength(100, ErrorMessage = "Max length for Email {1}.")]
        public string Email { get; set; }
    }
}