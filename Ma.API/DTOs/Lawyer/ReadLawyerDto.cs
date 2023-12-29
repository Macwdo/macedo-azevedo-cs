using System.ComponentModel.DataAnnotations;
using Ma.API.DTOs.User;

namespace Ma.API.DTOs.Lawyer;

public record ReadLawyerDto(
    int Id,
    string Name,
    string Email,
    string Cpf,
    string Oab,
    ReadUserDto? User,
    DateTime CreatedAt,
    DateTime UpdatedAt
    );
