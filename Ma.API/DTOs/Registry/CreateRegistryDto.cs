using System.ComponentModel.DataAnnotations;

namespace Ma.API.DTOs.Registry;

public record CreateRegistryDto(
    [Required, MinLength(3), MaxLength(40)] string Name,
    [Required, EmailAddress] string Email,
    Uri Image,
    int? LawyerId

);
