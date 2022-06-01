namespace Entities.Exceptions
{
    public class CollectionByIdsBadRequestException : Exception
    {
        public CollectionByIdsBadRequestException() 
            : base("Collection count mismatch comparing to ids.")
        {
        }
    }
}
