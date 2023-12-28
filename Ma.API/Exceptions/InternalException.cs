namespace Ma.API.Exceptions;


// TODO: Best exception handling
public class InternalException: Exception
{
    public InternalException()
    {
    }

    public InternalException(string? message) : base(message)
    {
    }
}