namespace Shared.DTO
{
    [Serializable]
    public record UserDto
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? Nickname { get; set; }
        public string? DateRegistration { get; set; }
    }
}
