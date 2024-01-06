using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.API.Entities.Lawsuit;

public class LawsuitFeesEntity: BaseEntity
{
    public required string Referent { get; set; }
    public double Value { get; set; }
    public bool IsGain { get; set; } = true;

    [ForeignKey("LawsuitId")]
    public int LawsuitId { get; set; }
    public required LawsuitEntity LawsuitEntity { get; set; }

    [ForeignKey("LawyerId")]
    public int LawyerId { get; set; }
    public required LawyerEntity LawyerEntity { get; set; }



}