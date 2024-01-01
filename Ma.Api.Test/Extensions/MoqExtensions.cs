using System.Net;
using System.Text.Json;
using Moq;
using Moq.Language.Flow;
using Moq.Protected;

namespace Ma.Api.Test.Extensions;

public static class MoqExtensions
{
    public static ISetup<HttpMessageHandler, Task<HttpResponseMessage>> SetupSendAsync(
        this Mock<HttpMessageHandler> handler,
        HttpMethod requestMethod,
        string requestUri
    )
    {
        return handler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
            ItExpr.Is<HttpRequestMessage>(r =>
                r.Method == requestMethod &&
                r.RequestUri != null &&
                r.RequestUri.ToString() == requestUri

            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    public static IReturnsResult<HttpMessageHandler> ReturnsHttpResponseAsync(
        this ISetup<HttpMessageHandler, Task<HttpResponseMessage>> moqSetup,
        object? responseBody,
        HttpStatusCode responseCode
    )
    {
        var serializedResponse = JsonSerializer.Serialize(responseBody);
        var stringContent = new StringContent(serializedResponse ?? string.Empty);

        var responseMessage = new HttpResponseMessage()
        {
            Content = stringContent,
            StatusCode = responseCode
        };

        return moqSetup.ReturnsAsync(responseMessage);


    }
}