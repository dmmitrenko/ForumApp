namespace ForumApp.Entities.Exceptions;

public class BlogNotFoundException : NotFoundException
{
    public BlogNotFoundException(Guid blogId)
        : base($"Blog with id: {blogId} doesn't exist in the database.")
    {
    }
}
