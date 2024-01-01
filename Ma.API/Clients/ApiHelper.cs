using System.Net;
using Exception = System.Exception;

namespace Ma.API.Clients;
public class ApiHelper: IApiHelper
{

    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiHelper> _logger;
    public ApiHelper(HttpClient httpClient, ILogger<ApiHelper> logger, string baseUrl)
    {
        httpClient.BaseAddress = new Uri(baseUrl);
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Response<T>> GetAsync<T>(string url)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<T>(url);
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Content = response
            };
        }
        catch (HttpRequestException)
        {
            throw new Exception("Http exception");
        }

    }

    public async Task<Response<T>> CallAsync<T>(string url, HttpMethod method, object body = null)
    {
        throw new NotImplementedException();
    }
}

public interface IApiHelper
{
    Task<Response<T>> GetAsync<T>(string url);
    Task<Response<T>> CallAsync<T>(string url, HttpMethod method, object body = null);
}


public class Response<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public required T Content { get; set; }
}

public class ErrorResponse
{
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; }
}