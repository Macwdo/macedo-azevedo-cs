using Ma.API.Models.User;

namespace Ma.API.Models.Lawyer;

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
