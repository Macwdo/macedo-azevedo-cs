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
    private IRepository<Lawsuit> _repository;

    public LawsuitsController(ILogger<LawsuitsController> logger, IRepository<Lawsuit> repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var lawsuits = _repository.GetAllReadOnly().ToList();
        return Ok(lawsuits);
    }

}