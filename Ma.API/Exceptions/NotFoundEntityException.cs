namespace Ma.API.Exceptions;

public class NotFoundEntityException: InternalException
{
    public NotFoundEntityException()
    {
    }

    public NotFoundEntityException(string? message) : base(message)
    {

    }
}