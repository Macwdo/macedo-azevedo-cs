using System.ComponentModel.DataAnnotations;
using Ma.API.DTOs.Lawyer;

namespace Ma.API.DTOs.Registry;

public record ReadRegistryDto(
    int Id,
    string Name,
    string Email,
    Uri Image,
    ReadLawyerDto? LawyerResponsible,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
