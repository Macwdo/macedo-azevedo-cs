using Ma.API.Models.Lawyer;

namespace Ma.API.Models.Registry;

public record ReadRegistryDto(
    int Id,
    string Name,
    string Email,
    Uri Image,
    ReadLawyerDto? LawyerResponsible,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
