using System.Net;
using FluentAssertions;
using Ma.API.Clients;
using Ma.Api.Test.Extensions;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Uri = System.Uri;

namespace Ma.Api.Test.System.Clients;


public class ApiHelperTest
{
    [Fact]
    public async Task GetAsync_OnSuccess_ReturnsResponse()
    {
        // Arrange
        var mockBaseUrl = "https://www.testbaseurl.com/testurl";

        var mockResponse = new Response<string>()
        {
            Content = "testResponseContent",
            StatusCode = HttpStatusCode.OK
        };

        var httpMessageHandler = new Mock<HttpMessageHandler>();
        httpMessageHandler
            .SetupSendAsync(HttpMethod.Get, mockBaseUrl)
            .ReturnsHttpResponseAsync(mockResponse, HttpStatusCode.OK);

        var mockLogger = new Mock<ILogger<ApiHelper>>();
        var mockHttpClient = new HttpClient(httpMessageHandler.Object)
        {
            BaseAddress = new Uri(mockBaseUrl)
        };
        var apiHelper = new ApiHelper(mockHttpClient, mockLogger.Object, mockBaseUrl);

        // Act
        var response = await apiHelper.GetAsync<Response<string>>("testurl");

        // Assert
        response.Content.Should().Be("some response");
    }
}
