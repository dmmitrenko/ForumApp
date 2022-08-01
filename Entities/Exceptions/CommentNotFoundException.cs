namespace ForumApp.Entities.Exceptions;

public class CommentNotFoundException : NotFoundException
{
    public CommentNotFoundException(Guid blogId)
        : base($"Comment with id: {blogId} doesn't exist in the database.")
    {
    }
}
