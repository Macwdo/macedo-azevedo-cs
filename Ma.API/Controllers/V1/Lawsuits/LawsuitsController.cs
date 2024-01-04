using System.Text.Json.Serialization;
using Ma.API.Entities.Lawsuit;
using Ma.API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ma.API.Controllers.V1.Lawsuits;


[ApiController]
[Route("api/v1/[controller]")]
public class LawsuitsController: ControllerBase
{
    private ILogger<LawsuitsController> _logger;

    public LawsuitsController(ILogger<LawsuitsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        throw new NotImplementedException();
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
