using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ma.API.Entities.Lawsuit;

public class LawsuitEntity: BaseEntity
{
    [Required]
    public string LawsuitCode { get; set; } = string.Empty;

    [Required, MinLength(3), MaxLength(255)]
    public string Subject { get; set; } = string.Empty;

    [Required, MinLength(3), MaxLength(500)]
    public string Observation { get; set; } = string.Empty;

    [Required]
    public ELawsuitClientPostion LawsuitClientPosition { get; set; }

    [Required]
    public ELawsuitType LawsuitType { get; set; }

    [ForeignKey("ResponsibleLawyerId"), Required]
    public int ResponsibleLawyerId { get; set; }
    public required LawyerEntity ResponsibleLawyer { get; set; }

    [ForeignKey("AdversePartId"), Required]
    public int AdversePartId { get; set; }
    public required RegistryEntity AdversePart {get; set; }

    [ForeignKey("ClientId"), Required]
    public int ClientId { get; set; }
    public RegistryEntity Client {get; set; }

    [ForeignKey("IndicatedById")]
    public int? IndicatedById { get; set; }
    public RegistryEntity? IndicatedBy { get; set; }

    public DateTime? InitialDate { get; set; }
    public DateTime? FinalDate { get; set; }


}
