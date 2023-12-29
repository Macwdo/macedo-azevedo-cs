using System.ComponentModel.DataAnnotations;

namespace Ma.API.Entities;

public class User: BaseEntity
{
    [Required, MinLength(3), MaxLength(40)]
    public string Name { get; set; }

    [Required, MinLength(3), MaxLength(40)]
    public string Surname { get; set; }
    [EmailAddress]
    public string Email { get; set; }
}