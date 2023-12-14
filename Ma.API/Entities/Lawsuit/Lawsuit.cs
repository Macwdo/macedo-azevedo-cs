using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.API.Entities.Lawsuit;

public class Lawsuit: BaseEntity
{
    public required string LawsuitCode { get; set; }

    public required string Subject { get; set; }

    public required string Observation { get; set; }

    public ELawsuitClientPostion LawsuitClientPosition { get; set; }
    public ELawsuitType LawsuitType { get; set; }

    [ForeignKey("ResponsibleLawyerId")]
    public int ResponsibleLawyerId { get; set; }
    public required Lawyer ResponsibleLawyer { get; set; }

    [ForeignKey("AdversePartId")]
    public int AdversePartId { get; set; }
    public required Registry AdversePart {get; set; }

    [ForeignKey("ClientId")]
    public int ClientId { get; set; }
    public required Registry Client {get; set; }

    [ForeignKey("IndicatedById")]
    public int? IndicatedById { get; set; }
    public Registry? IndicatedBy { get; set; }

    public DateTime? InitialDate { get; set; }
    public DateTime? FinalDate { get; set; }


}
