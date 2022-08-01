﻿namespace ForumApp.Entities.Responses;

public sealed class CollectionByIdsBadRequestResponse : ApiBadRequestResponse
{
    public CollectionByIdsBadRequestResponse() 
        : base("Collection count mismatch comparing to ids.")
    {
    }
}
