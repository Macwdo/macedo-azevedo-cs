using Ma.API.Entities.Lawsuit;
using Ma.API.Models.Lawyer;
using Ma.API.Models.Registry;

namespace Ma.API.Models.Lawsuit;

public record ReadLawsuitDto(
    int Id,
    string LawsuitCode,
    string Subject,
    string Observation,
    ELawsuitClientPostion LawsuitClientPosition,
    ELawsuitType LawsuitType,
    ReadLawyerDto ResponsibleLawyer,
    ReadRegistryDto AdversePart,
    ReadRegistryDto Client,
    ReadRegistryDto? IndicatedBy,
    DateTime? InitialDate,
    DateTime? FinalDate,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);