namespace ForumApp.Entities.Responses;

public sealed class IdParametersBadRequestResponse : ApiBadRequestResponse
{
    public IdParametersBadRequestResponse() 
        : base("Parameter ids is null")
    {
    }
}
