namespace Ma.API.Exceptions;

public class ServerErrorException: InternalException
{
    public ServerErrorException()
    {
    }

    public ServerErrorException(string? message) : base(message)
    {
    }
}