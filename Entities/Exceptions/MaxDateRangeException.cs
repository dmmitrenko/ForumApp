namespace ForumApp.Entities.Exceptions;

public class MaxDateRangeException : BadRequestException
{
    public MaxDateRangeException() 
        : base("Max date can't be less than min date")
    {
    }
}

