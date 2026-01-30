using System.ComponentModel.DataAnnotations;

namespace dtos.auth
{
    public class RegisterDto
    {
        public string? Username { get; set; } // Optional, for display/nickname
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}