using System.ComponentModel.DataAnnotations;

namespace Ma.API.DTOs.User;

public record ReadUserDto(
    int Id,
    string Name,
    string Surname,
    string Email,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
