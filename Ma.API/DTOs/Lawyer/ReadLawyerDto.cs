using System.ComponentModel.DataAnnotations;
using Ma.API.DTOs.User;

namespace Ma.API.DTOs.Lawyer;

public record ReadLawyerDto(
    string Name,
    string Email,
    string Cpf,
    string Oab,
    int? UserId,
    ReadUserDto? User,
    DateTime CreatedAt,
    DateTime UpdatedAt
    );
