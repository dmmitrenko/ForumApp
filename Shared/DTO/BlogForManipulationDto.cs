using System.ComponentModel.DataAnnotations;

namespace ForumApp.Shared.DTO;

public abstract record BlogForManipulationDto
{
    [Required(ErrorMessage = "Post title is a required field.")]
    [MinLength(5, ErrorMessage = "Minimum length for Title is 5 characters")]
    [MaxLength(30, ErrorMessage = "Maximum length for Title is 30 characters")]
    public string? Title { get; init; }

    [Required(ErrorMessage = "Post text is a required field.")]
    [MinLength(5, ErrorMessage = "Minimum length for Text is 5 characters")]
    public string? Text { get; init; }
    private DateTime LastChange { get; init; } = DateTime.Now;
}
