using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.API.Entities;

public class Registry: BaseEntity
{
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(100)]
    public string? Email { get; set; } = string.Empty;
    public Uri? Image { get; set; }


    [ForeignKey("LawyerResponsibleId")]
    public int? LawyerResponsibleId { get; set; }
    public Lawyer? LawyerResponsible { get; set; }
}