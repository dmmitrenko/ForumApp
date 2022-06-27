using System.ComponentModel.DataAnnotations;

namespace ForumApp.Shared.DTO;

public abstract record CommentForManipulationDto
{
    [Required(ErrorMessage = "Post text is a required field.")]
    [MinLength(5, ErrorMessage = "Minimum length for Text is 5 characters")]
    public string? Text { get; init; }
    private DateTime LastChange { get; init; } = DateTime.Now;
}
