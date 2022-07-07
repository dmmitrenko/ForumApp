namespace ForumApp.Entities.Responses;

public sealed class PostCollectionBadRequestResponse : ApiBadRequestResponse
{
    public PostCollectionBadRequestResponse() 
        : base("Post collection sent from a client is null.")
    {
    }
}
