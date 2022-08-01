namespace ForumApp.Entities.Responses;

public sealed class PostNotFoundResponse : ApiNotFoundResponse
{
    public PostNotFoundResponse(Guid id) 
        : base($"Post with id: {id} is not found in db.")
    {
    }
}
