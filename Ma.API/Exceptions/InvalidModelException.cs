using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;

namespace Ma.API.Exceptions;

public class InvalidModelException : Exception
{

    public InvalidModelException()
    {
        
    }

    public InvalidModelException(string message) : base(message)
    {
    }

    public Dictionary<string, string[]> Errors { get; }

    public InvalidModelException(Dictionary<string, string[]> errors)
    {
        Errors = errors;
    }


    public InvalidModelException(IEnumerable<string> errors) : base(string.Join(" | ", errors))
    {
        
    }
}