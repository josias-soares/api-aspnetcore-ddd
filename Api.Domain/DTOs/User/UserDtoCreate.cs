using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.User
{
    public class UserDtoCreate
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email um campo obrigatório")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres")]
        [EmailAddress]
        public string Email { get; set; }
    }
}