namespace Shared.DTO
{
    public record BlogForUpdateDto 
    {
        public string? Title { get; set; }
        public string? Text { get; set; }
        private DateTime LastChange { get; init; } = DateTime.Now; 
    }
}
