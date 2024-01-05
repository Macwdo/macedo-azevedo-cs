using System.Text.Json.Serialization;
using Ma.API.Entities.Lawsuit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ma.API.Controllers.V1.Lawsuits;


[ApiController]
[Route("api/v1/lawsuits")]
public class LawsuitController: ControllerBase
{
    private ILogger<LawsuitController> _logger;

    public LawsuitController(ILogger<LawsuitController> logger)
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
