namespace ForumApp.Shared.DTO;

public record UserForUpdateDto(string Name, string Surname, string Email, IEnumerable<BlogForCreationDto> Blogs);