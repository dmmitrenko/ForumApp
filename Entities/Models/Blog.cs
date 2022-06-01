using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Blog
    {
        [Column("BlogId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is a required field.")]
        [MinLength(5, ErrorMessage = "Minimum length for title is 5 characters")]
        [MaxLength(50, ErrorMessage = "Maximum length for title is 50 characters")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Text is a required field.")]
        [MinLength(5, ErrorMessage = "Minimum length for title is 5 characters")]
        public string? Text { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;
        public DateTime LastChange { get; set; } = DateTime.Now;

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
