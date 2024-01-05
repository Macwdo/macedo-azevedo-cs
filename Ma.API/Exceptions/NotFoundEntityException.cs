namespace Ma.API.Exceptions;

public class NotFoundEntityException: InternalException
{

    public NotFoundEntityException(int id) : base($"Entity with id {id} not found. Cannot delete entity with id {id}")
    {
    }

    public NotFoundEntityException(string entityName, int id) : base($"{entityName} with id {id} not found. Cannot delete entity with id {id}")
    {
    }

    public NotFoundEntityException(Type entityType, int id) : base($"{entityType} with id {id} not found. Cannot delete entity with id {id}")
    {
    }

    public NotFoundEntityException(string? message) : base(message)
    {

    }
}