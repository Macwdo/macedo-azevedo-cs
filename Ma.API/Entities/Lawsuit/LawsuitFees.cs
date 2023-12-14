using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.API.Entities.Lawsuit;

public class LawsuitFees
{
    public required string Referent { get; set; }
    public double Value { get; set; }
    public bool IsGain { get; set; } = true;

    [ForeignKey("LawsuitId")]
    public int LawsuitId { get; set; }
    public required Lawsuit Lawsuit { get; set; }

    [ForeignKey("LawyerId")]
    public int LawyerId { get; set; }
    public required Lawyer Lawyer { get; set; }



}