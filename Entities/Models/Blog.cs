using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumApp.Entities.Models;

public class Blog
{
    [Column("BlogId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Title is a required field.")]
    [MinLength(5, ErrorMessage = "Minimum length for title is 5 characters")]
    [MaxLength(30, ErrorMessage = "Maximum length for title is 50 characters")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Text is a required field.")]
    [MinLength(5, ErrorMessage = "Minimum length for title is 5 characters")]
    public string? Text { get; set; }

    public DateTime DateAdded { get; set; } = DateTime.Now;
    public DateTime LastChange { get; set; } = DateTime.Now;

    // navigation props
    public Guid UserId { get; set; }
    public List<Comment>? Comments { get; set; }
}
