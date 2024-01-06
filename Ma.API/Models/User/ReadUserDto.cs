namespace Ma.API.Models.User;

public record ReadUserDto(
    int Id,
    string Name,
    string Surname,
    string Email,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
