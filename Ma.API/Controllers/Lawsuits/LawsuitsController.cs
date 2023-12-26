using Microsoft.AspNetCore.Mvc;
using Ma.API.Entities;
using Ma.API.Entities.Lawsuit;
using Ma.API.Models;
using Ma.API.Repository;

namespace Ma.API.Controllers.Lawsuits;


[ApiController]
[Route("[controller]")]
public class LawsuitsController : ControllerBase
{
    private ILogger<LawsuitsController> _logger;
    private IRepository<Lawsuit> _lawsuitRepository;

    public LawsuitsController(ILogger<LawsuitsController> logger, IRepository<Lawsuit> lawsuitRepository)
    {
        _logger = logger;
        _lawsuitRepository = lawsuitRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Lawsuit>))]
    public IActionResult Get(
        string q,
        int skip,
        int take
        )
    {
        var lawsuits = _lawsuitRepository.Get();
        if (!string.IsNullOrEmpty(q))
        {
            lawsuits = lawsuits.Where(l =>
                (bool)
                (
                    l.LawsuitCode.Contains(q) |
                    l.Observation.Contains(q) |
                    l.Subject.Contains(q) |

                    l.ResponsibleLawyer.Email.Contains(q) |
                    l.ResponsibleLawyer.Name.Contains(q) |

                    l.Client.Name.Contains(q) |
                    l.Client.Email?.Contains(q) |

                    l.AdversePart.Name.Contains(q) |
                    l.AdversePart.Email?.Contains(q)

                )!
            );
        }

        return Ok(lawsuits);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Lawsuit))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Lawsuit))]
    public IActionResult Get(int id)
    {
        var lawsuit = _lawsuitRepository.Get(id);
        if (lawsuit is null)
        {
            return NotFound(new ApiErrorResult("Lawsuit not found", 404));
        }

        return Ok(lawsuit);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Lawsuit))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiErrorResult))]
    public IActionResult Post([FromBody] Lawsuit lawsuit)
    {
        var possibleLawsuit = _lawsuitRepository.Get().FirstOrDefault(l => l.LawsuitCode == lawsuit.LawsuitCode);
        if (possibleLawsuit is not null)
        {
            return BadRequest(new ApiErrorResult("Lawsuit already exists", 400));
        }

        _lawsuitRepository.Create(lawsuit);

        return CreatedAtAction(nameof(Get), new {id = lawsuit.Id}, lawsuit);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Lawsuit))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiErrorResult))]
    public IActionResult Put(int id, [FromBody] Lawsuit lawsuitUpdate)
    {
        var lawsuit = _lawsuitRepository.Get(id);
        if (lawsuit is null)
        {
            return NotFound(new ApiErrorResult("Lawsuit not found", 404));
        }
        _lawsuitRepository.Update(lawsuit);

        return CreatedAtAction(nameof(Get), new {id = lawsuit.Id}, lawsuit);
    }

    public IActionResult Delete(int id)
    {
        var lawsuit = _lawsuitRepository.Get(id);
        if (lawsuit is null)
        {
            return NotFound(new ApiErrorResult("Lawsuit not found", 404));
        }
        _lawsuitRepository.Delete(lawsuit);

        return NoContent();
    }


}