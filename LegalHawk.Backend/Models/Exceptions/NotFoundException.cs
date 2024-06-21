namespace LegalHawk.Backend.Models.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException()
    {
        ErrorCode = (int)HttpStatusCode.NotFound;
    }

    public NotFoundException(string message)
        : base(message)
    {
        ErrorCode = (int)HttpStatusCode.NotFound;
    }

    public NotFoundException(string message, Exception? innerException)
        : base(message, innerException)
    {
        ErrorCode = (int)HttpStatusCode.NotFound;
    }
}

