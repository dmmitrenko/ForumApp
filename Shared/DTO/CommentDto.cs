namespace ForumApp.Shared.DTO;

public record CommentDto(Guid Id, string Text, string DateAdded, string LastChange);