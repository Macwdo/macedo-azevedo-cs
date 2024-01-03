namespace Ma.API.Exceptions;


public class InternalException: Exception
{
    public InternalException()
    {
    }

    public InternalException(string? message) : base(message)
    {
    }
}