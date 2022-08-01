namespace ForumApp.Entities.Exceptions;

public sealed class PostCollectionBadRequest : BadRequestException
{
    public PostCollectionBadRequest()
        : base("Post collection sent from a client is null.")
    {
    }
}
