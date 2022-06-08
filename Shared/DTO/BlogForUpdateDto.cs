namespace Shared.DTO
{
    public record BlogForUpdateDto 
    {
        public string? Title { get; init; }
        public string? Text { get; init; }
        private DateTime LastChange { get; init; } = DateTime.Now; 
    }
}
