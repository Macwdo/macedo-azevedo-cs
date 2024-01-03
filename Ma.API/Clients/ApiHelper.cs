using System.Net;
using System.Text.Json;
using Ma.API.Exceptions;
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

    public async Task<Response<T?>> GetAsync<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);

        try
        {
            response.EnsureSuccessStatusCode();

            var responseBodyJsonString = await response.Content.ReadAsStringAsync();
            var responseBody = JsonSerializer.Deserialize<T>(responseBodyJsonString);
            return new Response<T?>()
            {
                StatusCode = response.StatusCode,
                Content = responseBody
            };
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error trying to request {url}, StatusCode: {statusCode}", url, response.StatusCode);
            throw new ClientErrorException($"Error trying to request {url}, StatusCode: {response.StatusCode}");
        }
    }

    public async Task<Response<T>> CallAsync<T>(string url, HttpMethod method, object body = null)
    {
        throw new NotImplementedException();
    }
}

public interface IApiHelper
{
    Task<Response<T?>> GetAsync<T>(string url);
    Task<Response<T>> CallAsync<T>(string url, HttpMethod method, object body = null);
}


public class Response<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public T? Content { get; set; }
}

public class ErrorResponse
{
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; }
}