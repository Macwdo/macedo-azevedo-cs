using System.ComponentModel.DataAnnotations;

namespace Ma.API.Models.Registry;

public record UpdateRegistryDto
(
    [MinLength(3), MaxLength(40)] string Name,
    [EmailAddress] string Email,
    //TODO: Validation for Image Uri
    Uri Image
);
