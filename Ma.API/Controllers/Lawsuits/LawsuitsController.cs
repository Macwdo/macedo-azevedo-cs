using Microsoft.AspNetCore.Mvc;
using Ma.API.Entities;
using Ma.API.Entities.Lawsuit;
using Ma.API.Repository;

namespace Ma.API.Controllers.Lawsuits;


[ApiController]
[Route("[controller]")]
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