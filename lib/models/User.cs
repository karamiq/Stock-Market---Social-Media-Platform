using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace models
{
    public class User: IdentityUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } 
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
