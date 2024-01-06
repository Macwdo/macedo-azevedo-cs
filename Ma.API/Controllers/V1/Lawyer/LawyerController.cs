using Ma.API.Models.Lawyer;
using Ma.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ma.API.Controllers.V1.Lawyer;


[ApiController]
[Route("api/v1/lawyers")]
public class LawyerController: GenericCrudControlller<Entities.LawyerEntity, CreateLawyerDto, ReadLawyerDto, UpdateLawyerDto>
{
    public LawyerController(IGenericCrudService<Entities.LawyerEntity, CreateLawyerDto, ReadLawyerDto, UpdateLawyerDto> service) : base(service)
    {
    }
}