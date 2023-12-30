using System.ComponentModel.DataAnnotations;
using Ma.API.Models.Validations;

namespace Ma.API.Models.Registry;

public record CreateRegistryDto(
    [Required, MinLength(3), MaxLength(40)] string Name,
    [Required, EmailAddress] string Email,
    Uri Image,
    [EntityExistsValidation<Entities.Lawyer>]
    int? LawyerResponsibleId

);
