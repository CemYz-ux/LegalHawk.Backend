namespace LegalHawk.Backend.Models.Exceptions.Base;

public class BaseException : Exception
{
    public int ErrorCode { get; set; }

    public BaseException()
    {
    }

    public BaseException(string message)
    : base(message)
    {
    }

    public BaseException(string message, Exception? inner)
    : base(message, inner)
    {
    }
}
