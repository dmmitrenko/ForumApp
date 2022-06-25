namespace ForumApp.Entities.Exceptions;

public sealed class UserCollectionBadRequest : BadRequestException
{
    public UserCollectionBadRequest()
        : base("User collection sent from a client is null.")
    {
    }
}
