namespace Shared.DTO
{
    [Serializable]
    public record UserDto(Guid Id, string FullName, string Nickname, string DateRegistration);
}
