namespace Shared.DTO
{
    public record UserForCreationDto(string Name, string Surname, string Nickname, string Email, IEnumerable<BlogForCreationDto> blogs);
}
