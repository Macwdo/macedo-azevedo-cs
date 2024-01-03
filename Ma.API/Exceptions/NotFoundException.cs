namespace Ma.API.Exceptions;

public class NotFoundException: InternalException
{
    public NotFoundException(string? message) : base(message)
    {
    }
}