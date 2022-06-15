using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public abstract record BlogForManipulationDto
    {
        [Range(5, 30, ErrorMessage = "Title is required and it can't be lower than 5.")]
        public string? Title { get; init; }

        [Required(ErrorMessage = "Post text is a required field.")]
        [MinLength(5, ErrorMessage = "Minimum length for Text is 5 characters")]
        public string? Text { get; init; }
        private DateTime LastChange { get; init; } = DateTime.Now;
    }
}
