using System.ComponentModel.DataAnnotations;

namespace Ma.API.DTOs.User;

public record ReadUserDto(
    string Name,
    string Surname,
    string Email,
    DateTime BirthDate,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
