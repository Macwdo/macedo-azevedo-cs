using System.Text.Json.Serialization;
using Ma.API.Clients;
using Ma.API.Entities.Lawsuit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ma.API.Controllers.V1.Lawsuits;


[ApiController]
[Route("api/v1/[controller]")]
public class LawsuitsController: ControllerBase
{
    private ILogger<LawsuitsController> _logger;
    private IApiHelper _apiHelper;

    public LawsuitsController(ILogger<LawsuitsController> logger, IApiHelper apiHelper)
    {
        _logger = logger;
        _apiHelper = apiHelper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _apiHelper.GetAsync<FlaskResponse>("/");
        return Ok(response.Content);
    }

    [HttpPost]
    public IActionResult Post(Lawsuit lawsuit)
    {
        throw new NotImplementedException();
    }

}

public class FlaskResponse
{
    [JsonProperty("message")]
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}
