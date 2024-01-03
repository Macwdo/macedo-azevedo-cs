using System.ComponentModel.DataAnnotations;
using Ma.API.Validators;

namespace Ma.API.Models.Registry;

public record CreateRegistryDto(
    [Required, MinLength(3), MaxLength(100)] string Name,
    [Required, EmailAddress, MaxLength(100)] string? Email,
    Uri? Image,
    [EntityExistsValidator<Entities.Lawyer>]
    int? LawyerResponsibleId

);
