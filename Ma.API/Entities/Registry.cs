using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.API.Entities;

public class Registry: BaseEntity
{
    public required string Name { get; set; }
    public string? Email { get; set; }
    public Uri? Image { get; set; }


    [ForeignKey("LawyerResponsibleId")]
    public int? LawyerResponsibleId { get; set; }
    public Lawyer? LawyerResponsible { get; set; }
}