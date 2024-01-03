namespace Ma.API.Exceptions;

public class InvalidModelException : Exception
{

    public InvalidModelException()
    {
        
    }

    public InvalidModelException(string message) : base(message)
    {
    }

    public InvalidModelException(IEnumerable<string> errors) : base(string.Join(" | ", errors))
    {
        
    }
}