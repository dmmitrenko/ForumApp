namespace ForumApp.Entities.Exceptions;

public sealed class PostNotFoundException : NotFoundException
{
    public PostNotFoundException(Guid userId)
        : base($"The post with id: {userId} doesn't exist in the database.")
    {
    }
}
