using System.ComponentModel.DataAnnotations;
using Ma.API.Validators;

namespace Ma.API.Models.Registry;

public record UpdateRegistryDto
(
    [MinLength(3), MaxLength(100)] string? Name,
    [EmailAddress, MaxLength(100)] string? Email,
    //TODO: Validation for Image Uri
    Uri? Image,
    [EntityExistsValidator<Entities.Lawyer>]
    int? LawyerResponsibleId
);
