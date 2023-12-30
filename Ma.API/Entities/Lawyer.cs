using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.API.Entities;

public class Lawyer: BaseEntity
{
    [StringLength(60)]
    public string Name { get; set; } = string.Empty;
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;
    [StringLength(11)]
    public string Cpf { get; set; } = string.Empty;

    [ForeignKey("UserId")]
    public int? UserId { get; set; }
    public User? User { get; set; }
    [StringLength(20)]
    public string Oab { get; set; } = string.Empty;

}