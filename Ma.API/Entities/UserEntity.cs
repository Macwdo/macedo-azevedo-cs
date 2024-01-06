using System.ComponentModel.DataAnnotations;

namespace Ma.API.Entities;

public class UserEntity: BaseEntity
{
    [Required, MinLength(3), MaxLength(40)]
    public string Name { get; set; } = string.Empty;

    [Required, MinLength(3), MaxLength(40)]
    public string Surname { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}