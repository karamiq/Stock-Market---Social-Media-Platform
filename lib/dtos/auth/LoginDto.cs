using System.ComponentModel.DataAnnotations;

namespace dtos.auth
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]

        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }

}