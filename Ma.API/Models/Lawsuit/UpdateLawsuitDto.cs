using System.ComponentModel.DataAnnotations;
using Ma.API.Entities.Lawsuit;

namespace Ma.API.Models.Lawsuit;

public record UpdateLawsuitDto(
    string? LawsuitCode,
    string? Subject,
    string? Observation,
    ELawsuitClientPostion? LawsuitClientPosition,
    ELawsuitType? LawsuitType,
    int? ResponsibleLawyerId,
    int? AdversePartId,
    int? ClientId,
    int? IndicatedById,
    DateTime? InitialDate,
    DateTime? FinalDate
    );