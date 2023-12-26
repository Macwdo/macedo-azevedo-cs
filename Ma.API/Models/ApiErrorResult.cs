namespace Ma.API.Models;

public class ApiErrorResult
{
    public string Message { get; set; }
    public int StatusCode { get; set; }

    public ApiErrorResult(string message, int statusCode)
    {
        Message = message;
        StatusCode = statusCode;
    }
}

