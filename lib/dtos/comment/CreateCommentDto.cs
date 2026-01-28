using System.ComponentModel.DataAnnotations;

namespace api.dtos.comment
{
    public class CreateCommentDto
    {
        [Required]
        [MaxLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        [MinLength(5, ErrorMessage = "Title must be at least 5 characters long.")]
        public string title { get; set; } = string.Empty;
        [Required]
        [MaxLength(1000, ErrorMessage = "Content cannot exceed 1000 characters.")]
        [MinLength(10, ErrorMessage = "Content must be at least 10 characters long.")]
        public string content { get; set; } = string.Empty;
    }
}