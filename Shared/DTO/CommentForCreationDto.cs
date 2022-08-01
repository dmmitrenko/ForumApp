namespace ForumApp.Shared.DTO;

public record CommentForCreationDto : CommentForManipulationDto
{
    public Guid UserId { get; init; }
}