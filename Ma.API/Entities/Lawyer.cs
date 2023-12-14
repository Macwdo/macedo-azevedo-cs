using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.API.Entities;

public class Lawyer: BaseEntity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Cpf { get; set; }

    [ForeignKey("UserId")]
    public int? UserId { get; set; }
    public User? User { get; set; }
    public required string Oab { get; set; }

}