using Ma.API.Entities.Lawsuit;
using Ma.API.Models.Lawsuit;
using Ma.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ma.API.Controllers.V1.Lawsuits;


[ApiController]
[Route("api/v1/lawsuits")]
public class LawsuitController : GenericCrudControlller<LawsuitEntity, CreateLawsuitDto, ReadLawsuitDto, UpdateLawsuitDto>
{
    public LawsuitController(IGenericCrudService<LawsuitEntity, CreateLawsuitDto, ReadLawsuitDto, UpdateLawsuitDto> service) : base(service)
    {
    }
}
