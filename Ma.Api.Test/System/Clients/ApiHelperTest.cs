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

        var mockRequest = "testResponseContent";

        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler
            .SetupSendAsync(HttpMethod.Get, mockBaseUrl)
            .ReturnsHttpResponseAsync(mockRequest, HttpStatusCode.OK);

        var mockLogger = new Mock<ILogger<ApiHelper>>();
        var mockHttpClient = new HttpClient(mockHttpMessageHandler.Object)
        {
            BaseAddress = new Uri(mockBaseUrl
)
        };
        var apiHelper = new ApiHelper(mockHttpClient, mockLogger.Object, mockBaseUrl);

        // Act
        var response = await apiHelper.GetAsync<string>("testurl");

        // Assert
        response.Content.Should().Be("testResponseContent");
    }

    [Fact]
    async Task GetAsync_OnErrorStatusCode_ThrowsAnError()
    {
        // Arrange
        var mockBaseUrl = "https://www.testbaseurl.com/testurl";
        var mockRequest = "testResponseContent";

        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler
            .SetupSendAsync(HttpMethod.Get, mockBaseUrl)
            .ReturnsHttpResponseAsync(mockRequest, HttpStatusCode.NotFound);

        var mockLogger = new Mock<ILogger<ApiHelper>>();
        var mockHttpClient = new HttpClient(mockHttpMessageHandler.Object)
        {
            BaseAddress = new Uri(mockBaseUrl
            )
        };
        var apiHelper = new ApiHelper(mockHttpClient, mockLogger.Object, mockBaseUrl);

        // Act
        var response = await apiHelper.GetAsync<string>("testurl");

        // Assert
        response.Should().Be("1");
    }
}
