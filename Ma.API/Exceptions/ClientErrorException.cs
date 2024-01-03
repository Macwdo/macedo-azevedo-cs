namespace Ma.API.Exceptions;

public class ClientErrorException: InternalException
{
    public ClientErrorException()
    {
    }

    public ClientErrorException(string? message) : base(message)
    {
    }
}